using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTNIntegration.OTNUrls
{
    public static class OtnUrl
    {
        public static string GetProjectUrl = "v1/projects";
        public static string GetWorkFlowStepsUrl = "v1/workflows/";
        public static string GetUsersUrl = "v1/users";
        public static string GetReleasesUrl = "v1/releases";
        public static string GetPrioritiesUrl = "v1/picklists/priority";
        public static string GetTaskUrl = "v1/features";
        public static string GetSecurityRolesUrl = "v1/security_roles";

        public static string AddProjectUrl = "v1/projects";
        public static string AddActivityUrl = "v1/features";
        public static string AddUserUrl = "v1/users";
        public static string AddWorkLogUrl = "v1/work_logs";

        public static string UpdateUserUrl = "v1/users/";
        public static string UpdateProjectUrl = "v1/projects/";
        public static string UpdateActivityUrl = "v1/features/";
    }
}
