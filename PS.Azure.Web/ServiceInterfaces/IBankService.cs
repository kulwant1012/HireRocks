using PS.Data.Entities;
using PS.Data.Entities.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IBankService
    {
        OperationResult<BankAccount> GetPSBankAccount();

        [OperationContract]
        OperationResult<List<MoneyTransaction>> LoadMoney(string userId);
    }
}