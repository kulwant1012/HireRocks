using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.HireRocks.Web.Helpers
{
    public static class SessionNameConstants
    {
        public const string LogedInUserSession = "LogedInUserSession";
        public const string CompleteProfileSession = "CompleteProfileSession";
        public const string PostJobViewModelSession = "PostJobViewModelSession";
        public const string SuccessMessage = "SuccessMessage";
        public const string HireWorkerScreenSession = "HireWorkerScreenSession";
        public const string ContractSession = "ContractSession";
        public const string FindJobScreenViewModel = "FindJobScreenViewModel";
        public const string WorkerSelectedForContract = "WorkerSelectedForContract";
        public const string TotalHoursBurned = "TotalHoursBurned";
    }
}