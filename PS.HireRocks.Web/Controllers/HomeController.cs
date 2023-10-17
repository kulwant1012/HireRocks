using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
          
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult GetTracker()
        {
            return View();
        }
        public ActionResult DownloadSetup()
        {
    
            string path = @"C:\Users\Hp\Desktop\premium accs.txt";
            string content = "application/txt";
            //string content = "application/x-ms-application";
            return new FilePathResult(path, content)
            {
                FileDownloadName = "mynewtext.txt"
            };
        }
    }
}