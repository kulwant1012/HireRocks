using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PS.HireRocks.WebApi.Models;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Controllers;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/UserDetail")]
    public class UserDetailController : BaseController
    {          
        [HttpGet]
        [Authorize]
        [Route("WorkerDetail")]
        public async Task<IHttpActionResult> WorkerDetail(string workerId)
        {
            GetUserByIdViewModel getUserByIdViewModel = new GetUserByIdViewModel();
            getUserByIdViewModel =  new UserDetailRepository().GetWorkerInfoByWorkerId(workerId);
            return Ok(getUserByIdViewModel);
        }
        [HttpGet]
        [Authorize]
        [Route("GetWorkerJobs")]
        public async Task<IHttpActionResult> GetWorkerJobs(string workerId)
        {
            IEnumerable<WorkerJobsViewModel> WorkerJobs = new List<WorkerJobsViewModel>();
            WorkerJobs = await ExecuteFunction(() => new UserDetailRepository().GetWorkerJobs(workerId));
            return Ok(WorkerJobs);
        }

	}
}