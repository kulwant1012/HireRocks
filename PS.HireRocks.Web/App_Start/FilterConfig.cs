using PS.HireRocks.Web.Helpers;
using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionHandler());
            filters.Add(new CustomAuthorization());
        }
    }
}
