using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Web.Helpers
{
    public class CustomAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (!skipAuthorization)
            {
                var logedInUserSession = filterContext.HttpContext.Session[SessionNameConstants.LogedInUserSession];
                if (logedInUserSession == null)
                    filterContext.Result = new HttpUnauthorizedResult();
            }
               //filterContext.HttpContext.Response.Redirect("/Account/LogOff");
            base.OnAuthorization(filterContext);
        }
    }
}