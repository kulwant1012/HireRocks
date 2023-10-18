using PS.Azure.Web.Services;
using PS.Azure.Web.Utils;
using PS.Data.Entities;
using PS.Data.Entities.Money;
using PS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web
{
    public partial class PSService : IWalletService
    {
        #region IWalletService
        public OperationResult<BankAccount> GetBankAccountById(string bankAccountId, string userId)
        {            
            return TryInvoke(() => _usersRepository.GetById(userId).Wallet.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId));            
        }

        public OperationResult<List<BankAccount>> GetAllBankAccounts(string userId)
        {            
            return TryInvoke(() => _usersRepository.GetById(userId).Wallet.BankAccounts.OrderBy(x => x.Status).ThenBy(x => x.AccountNickName).ToList());                
        }

        public OperationResult<List<BankAccount>> GetVerifiedBankAccounts(string userId)
        {
            return TryInvoke(() => _usersRepository.GetById(userId).Wallet.BankAccounts.Where(x => x.Status == BankAccountStatus.Verified).OrderBy(x => x.Status).ThenBy(x => x.AccountNickName).ToList());
        }

        public OperationResult InsertOrUpdateBankAccount(BankAccount bankAccount, string userId)
        {
            return TryInvoke(() =>
            {
                var user = _usersRepository.GetById(userId);
                if (user.Wallet == null)
                    user.Wallet = new Wallet();
                var existedBankAccount = user.Wallet.BankAccounts.FirstOrDefault(x => x.Id == bankAccount.Id);
                if (existedBankAccount == null)
                {
                    bankAccount.CreatedDate = DateTime.UtcNow;
                    bankAccount.UpdatedDate = DateTime.UtcNow;
                    user.Wallet.BankAccounts.Add(bankAccount);
                }
                else
                {
                    user.Wallet.BankAccounts.Remove(existedBankAccount);
                    bankAccount.UpdatedDate = DateTime.UtcNow;
                    user.Wallet.BankAccounts.Add(bankAccount);
                }

                _usersRepository.InsertOrUpdate(user);                
            });
        }

        public OperationResult DeleteBankAccount(string bankAccountId, string userId)
        {
            return TryInvoke(() =>
            {
                var user = _usersRepository.GetById(userId);
                var bankAccount = user.Wallet.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);
                if (bankAccount != null)
                    user.Wallet.BankAccounts.Remove(bankAccount);

                _usersRepository.InsertOrUpdate(user);
            });
        }

        public OperationResult DoVerificationTransactions(string bankAccountId, string userId)
        {
            return TryInvoke(() =>
            {                
                var user = _usersRepository.GetById(userId);
                var bankAccount = user.Wallet.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);
                if (bankAccount.Status != BankAccountStatus.Logged)
                    return OperationResult.Error("Verification status is: " + bankAccount.Status.ToString());

                // todo : micro transaction 1
                bankAccount.VerificationTransaction1Amount = 0.1F;
                // todo : micro transaction 2
                bankAccount.VerificationTransaction2Amount = 0.2F;

                bankAccount.Status = BankAccountStatus.InProgress;

                _usersRepository.InsertOrUpdate(user);

                return OperationResult.Success();
            });
        }

        public OperationResult VerifyBankAccount(string bankAccountId, float transaction1Amount, float transaction2Amount, string userId)
        {
            return TryInvoke(() =>
            {
                var user = _usersRepository.GetById(userId);
                var bankAccount = user.Wallet.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);
                if (bankAccount.Status != BankAccountStatus.InProgress)
                    return OperationResult.Error("Need initialize verification before. 2 micro transactions");
                else if (bankAccount.VerificationAttemptsLeft >= 3)
                {                    
                    return OperationResult.Error("You used 3 attempts to verification. Please delete bank account and add again.");
                }
                else if (bankAccount.VerificationTransaction1Amount != transaction1Amount)
                {
                    bankAccount.VerificationAttemptsLeft++;
                    _usersRepository.InsertOrUpdate(user);
                    return OperationResult.Error("Transaction 1 amount is not equivalent" + Environment.NewLine +
                        string.Format("You used {0} from 3 attempts to verification", bankAccount.VerificationAttemptsLeft));
                }
                else if (bankAccount.VerificationTransaction2Amount != transaction2Amount)
                {
                    bankAccount.VerificationAttemptsLeft++;
                    _usersRepository.InsertOrUpdate(user);
                    return OperationResult.Error("Transaction 2 amount is not equivalent" + Environment.NewLine +
                        string.Format("You used {0} from 3 attempts to verification", bankAccount.VerificationAttemptsLeft));
                }
                else
                {
                    bankAccount.Status = BankAccountStatus.Verified;
                    _usersRepository.InsertOrUpdate(user);
                    return OperationResult.Success();
                }
            });
        }
        #endregion

        public OperationResult<double> GetBalance(string userId)
        {            
            return TryInvoke<double>(() =>
                {                    
                    var loaded = _moneyTransactionsRepository.GetAll().Where(x => x.Type == MoneyTransactionType.LoadMoney && x.ToUserId == userId).Sum(x => x.Amount);
                    var withdrawn = _moneyTransactionsRepository.GetAll().Where(x => x.Type == MoneyTransactionType.WithdrawMoney && x.ToUserId == userId).Sum(x => x.Amount);
                    var transferToMe = _moneyTransactionsRepository.GetAll().Where(x => x.Type == MoneyTransactionType.TransferMoney && x.ToUserId == userId).Sum(x => x.Amount);
                    var transferFromMe = _moneyTransactionsRepository.GetAll().Where(x => x.Type == MoneyTransactionType.TransferMoney && x.FromUserId == userId).Sum(x => x.Amount);
                    
                    return loaded + transferToMe - transferFromMe - withdrawn;
                });            
        }

        public OperationResult LoadMoney(double amount, MoneyLoadDetail moneyLoadDetails, string userId, string pushChannel)
        {            
            return TryInvoke(() =>
                {                    
                    var trans = new MoneyTransaction()
                    {                        
                         Amount = amount,
                         DatePosted = DateTime.UtcNow,
                         Type = MoneyTransactionType.LoadMoney,        
                         MoneyLoadDetail = moneyLoadDetails,
                         FromUserId = userId,
                         ToUserId = userId,
                         PushChannel = pushChannel
                    };
                    _moneyTransactionsRepository.InsertOrUpdate(trans);
                });            
            
        }

        public OperationResult TransferMoney(double amount, MoneyTransferDetail moneyTransferDetails, string fromUserId, string toUserId, string pushChannel)
        {
            return TryInvoke(() =>
            {
                var trans = new MoneyTransaction()
                {
                    Amount = amount,
                    DatePosted = DateTime.UtcNow,
                    Type = MoneyTransactionType.TransferMoney,
                    MoneyTransferDetail = moneyTransferDetails,
                    FromUserId = fromUserId,
                    ToUserId = toUserId,
                    PushChannel = pushChannel
                };
                _moneyTransactionsRepository.InsertOrUpdate(trans);
            });

        }

        public OperationResult WithdrawMoney(double amount, MoneyWithdrawDetail moneyWithdrawDetails, 
            string userId, string pushChannel)
        {
            return TryInvoke(() =>
            {
                var trans = new MoneyTransaction()
                {
                    Amount = amount,
                    DatePosted = DateTime.UtcNow,
                    Type = MoneyTransactionType.WithdrawMoney,
                    MoneyWithdrawDetail = moneyWithdrawDetails,
                    FromUserId = userId,
                    ToUserId = userId,
                    PushChannel = pushChannel
                };
                _moneyTransactionsRepository.InsertOrUpdate(trans);
            });
        }

        public OperationResult<List<MoneyTransaction>> GetPendingTransactions(string userId)
        {            
            return TryInvoke<List<MoneyTransaction>>(() => _moneyTransactionsRepository.Search(x => x.FromUserId == userId || x.ToUserId == userId && x.Status == MoneyTransactionStatus.InProcess).ToList());            
        }

        public OperationResult<double> GetPendingTransactionsAmount(string userId)
        {            
            return TryInvoke<double>(() => _moneyTransactionsRepository.Search(x => x.FromUserId == userId || x.ToUserId == userId && x.Status == MoneyTransactionStatus.InProcess).Sum(x => x.Amount));
        }

        public OperationResult<List<MoneyTransaction>> GetAllTransactions(string userId)
        {            
            return TryInvoke<List<MoneyTransaction>>(() => _moneyTransactionsRepository.Search(x => x.FromUserId == userId || x.ToUserId == userId).ToList());
        }
    }
}
