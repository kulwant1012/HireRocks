using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Models;
using PS.HireRocks.WebApi.Controllers;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/Team")]
    public class TeamController : BaseController
    {
        public TeamController()
       : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public TeamController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        [HttpGet]
        [Authorize]
        [Route("GetTeamsGridData")]
        public async Task<IHttpActionResult> GetTeamsGridData(long? jobId, bool? showActiveWorkers)
        {
            IEnumerable<GetWorkerViewModel> teamList = null;
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
                teamList = await ExecuteFunction(() => new WorkerRepository().GetClientTeam(user.Id,jobId,showActiveWorkers));
            return Ok(teamList);
        }


        [HttpGet]
        [Authorize]
        [Route("GetJobList")]
        public async Task<IHttpActionResult> GetJobList()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return Json(await ExecuteFunction(() => new MessageRepository().GetClientJobList(user.Id)));
        }
    }
}