using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PS.HireRocks.Data.Helpers;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.WebApi.Helpers;

namespace PS.HireRocks.WebApi.Controllers
{
    [Authorize(Roles = RoleConstants.Worker)]  
    [RoutePrefix("api/WorkerContract")]
    public class WorkerContractController : BaseController
    {
        public WorkerContractController()
      : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public WorkerContractController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public async Task<IHttpActionResult> ReviewContract(long? id)
        {
            ContractViewModel contractViewModel = null;
            if (id.HasValue)
                contractViewModel = await ExecuteFunction(() => new WorkerRepository().GetContractForReviewByContractId(id));
            return Ok(contractViewModel);
        }


        [HttpGet]
        [Authorize]
        [Route("GetContractDenyReasonsByRole")]
        public async Task<IHttpActionResult> GetContractDenyReasonsByRole()
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var role = user.Roles.FirstOrDefault().RoleId;
            return Json(await ExecuteFunction(() => new ContractRepository().GetContractDenyReasonsByRoleId(user.Roles.FirstOrDefault().RoleId)));
        }

        [HttpPost]
        [Authorize]
        [Route("ApproveContract")]      
        public async Task<IHttpActionResult> ApproveContract(long? id,long jobId)
        {
            if (id.HasValue)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                await ExecuteFunction(() => new WorkerRepository().ApproveContract(id.Value, user.Id,jobId));
            }
            return Ok("Contract approved successfully.");
        }

        [HttpPost]
        public async Task<IHttpActionResult> RejectContract(RejectContractViewModel model)
        {
            string[] validationErrors = null;
            if (model.EndReasonId != (long)ContractDenyReasonEnum.Other)
                ModelState.Remove("model.OtherEndReason");
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                model.ModifiedByUserId = user.Id;
                await ExecuteFunction(() => new ContractRepository().RejectContract(model));
            }
            else
                validationErrors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
            return Json(new { result = validationErrors });
        }

        public async Task<IHttpActionResult> ManageContract(long? contractId)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return Ok(await ExecuteFunction(() => new WorkerRepository().GetManageContractScreenData(contractId, user.Id)));
        }

        [HttpPost]
        public async Task<IHttpActionResult> ManageContract(ContractViewModel model)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            model.WorkerId = user.Id;
            ModelState.Remove("EstimatedDuration");
            ModelState.Remove("TimeUnitId");
            ModelState.Remove("JobId");
            ModelState.Remove("WorkerId");
            ModelState.Remove(model.JobTypeId == (long)JobTypeEnum.Fixed ? "HourlyRate" : "FixedRate");
            ModelState.Remove(model.EndReasonId == (long)ContractEndReasonEnum.Other ? "EndReason" : "OtherEndReason");
            if (!model.IsEndingContract)
            {
                ModelState.Remove("EndReasonId");
                ModelState.Remove("OtherEndReason");
                ModelState.Remove("UserRatingsViewModel.Comment");
            }
            if (model.COntractStatusId == ContractStatusConstants.Closed)
            {
                ModelState.Remove("EndReasonId");
                ModelState.Remove("OtherEndReason");
            }
            if (ModelState.IsValid)
            {
                await ExecuteFunction(() => new WorkerRepository().UpdateContractForWorker(model));               
                return Ok(new { contractId = model.ContractId });
            }
            return Ok(model);
        }
    }
}