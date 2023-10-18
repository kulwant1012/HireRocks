using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IInitializationService
    {
        [OperationContract]
        OperationResult InitializeRavenDb(string connectionString);

        [OperationContract]
        OperationResult SendEmails(DateTime cutTime);
    }
}