using PS.Data.Repositories.AOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PS.Azure.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            PSService PSService = new PSService();
            PSService.InitializeRavenDb("AOSDataBase");
            PSService.InsertDefaultData();

            AOSUserRepository aosUserRepository = new AOSUserRepository();
            TimerCallback callBack = aosUserRepository.SendDailyWorkProgress;
            Timer timer = new Timer(callBack);
            DateTime now = DateTime.Now;           
            DateTime timeToSendEmail = DateTime.Today.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["SendWorkProgressAt"])).AddMinutes(13);
            if (now > timeToSendEmail)
                timeToSendEmail = timeToSendEmail.AddDays(1.0);
            int msUntilFour = (int)((timeToSendEmail - now).TotalMilliseconds);
            timer.Change(msUntilFour, Timeout.Infinite);            

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}