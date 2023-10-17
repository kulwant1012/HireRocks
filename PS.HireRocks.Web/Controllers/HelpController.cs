using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Web.Controllers
{
    [AllowAnonymous]
    public class HelpController : BaseController
    {
        //
        // GET: /Help/
        public ActionResult Help()
        {
            return View();
        }
	}
}