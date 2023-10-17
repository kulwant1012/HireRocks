using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Web.Models;
using PS.HireRocks.Data.Helpers;
using System.Globalization;
using Microsoft.AspNet.Identity;
using System.IO;

namespace PS.HireRocks.Web.Controllers
{
    public class MyAccountController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];          

            if (user != null)
            {                
                if (User.IsInRole(RoleConstants.Worker)) 
                {
                    List<WorkerJobsViewModel> jobsList = new List<WorkerJobsViewModel>();
                    var result = new JobRepository().GetJobsByWorkerId(user.Id, null);
                    jobsList = result;
                    ViewBag.jobcount = jobsList.Count();
                }
                else
                {
                    List<GetJobsViewModel> jobsList = new List<GetJobsViewModel>();
                    var result = await new JobRepository().GetJobsByClientId(user.Id);
                    if (!result.IsErrorReturned && result.Value != null)
                        jobsList = result.Value;
                    ViewBag.jobcount = jobsList.Count();
                }
            } 
                      
            return View();           
        }
	}
}