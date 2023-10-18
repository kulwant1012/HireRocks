using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Tracker.Helpers
{
    public static class AppConstants
    {
        public const string SQLConnectionName = "Defaultcon";
        public const string RavenConnectionName = "RavenConnection";
        public const string CryptographyPassword = "PSTracker";
    }

    public static class StoredProcedureNames
    {
        public const string AuthenticateUser = "AuthenticateUser";
        public const string GetProjectsByUserId = "GetProjectsByUserId";
        public const string GetJobsByWorkerId = "GetJobsByWorkerId";
        public const string InsertCapture = "InsertCapture";
    }
}
