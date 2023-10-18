using PS.Data.Entities;
using PS.Data.Entities.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IWalletService
    {
        [OperationContract]
        OperationResult<double> GetBalance(string userId);

        [OperationContract]
        OperationResult LoadMoney(double amount, MoneyLoadDetail moneyLoadDetail, string userId, string pushChannel);        

        [OperationContract]
        OperationResult TransferMoney(double amount, MoneyTransferDetail moneyTransferDetail, string fromUserId, string toUserId, string pushChannel);

        [OperationContract]
        OperationResult WithdrawMoney(double amount, MoneyWithdrawDetail moneyWithdrawDetail, string userId, string pushChannel);

        [OperationContract]
        OperationResult<List<MoneyTransaction>> GetPendingTransactions(string userId);

        [OperationContract]
        OperationResult<double> GetPendingTransactionsAmount(string userId);

        [OperationContract]
        OperationResult<List<MoneyTransaction>> GetAllTransactions(string userId);        

        [OperationContract]
        OperationResult<BankAccount> GetBankAccountById(string bankAccountId, string userId);

        [OperationContract]
        OperationResult<List<BankAccount>> GetAllBankAccounts(string userId);

        [OperationContract]
        OperationResult<List<BankAccount>> GetVerifiedBankAccounts(string userId);

        [OperationContract]
        OperationResult InsertOrUpdateBankAccount(BankAccount bankAccount, string userId);

        [OperationContract]
        OperationResult DeleteBankAccount(string bankAccountId, string userId);

        [OperationContract]
        OperationResult DoVerificationTransactions(string bankAccountId, string userId);

        [OperationContract]
        OperationResult VerifyBankAccount(string bankAccountId, float transaction1Amount, float transaction2Amount, string userId);
    }
}
