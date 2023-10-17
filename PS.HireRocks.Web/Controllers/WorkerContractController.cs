using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PS.HireRocks.Data.Helpers;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;

namespace PS.HireRocks.Web.Controllers
{
    [Authorize(Roles = RoleConstants.Worker)]
    public class WorkerContractController : BaseController
    {
        public async Task<ActionResult> ReviewContract(long? id)
        {
            ContractViewModel contractViewModel = null;
            if (id.HasValue)
                contractViewModel = await ExecuteFunction(() => new WorkerRepository().GetContractForReviewByContractId(id));
            return View(contractViewModel);
        }

        public async Task<ActionResult> GetContractDenyReasonsByRole()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            var role = user.Roles.FirstOrDefault().RoleId;
            return Json(await ExecuteFunction(() => new ContractRepository().GetContractDenyReasonsByRoleId(user.Roles.FirstOrDefault().RoleId)), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ApproveContract(long? id,long jobId)
        {
            if (id.HasValue)
            {
                ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
                await ExecuteFunction(() => new WorkerRepository().ApproveContract(id.Value, user.Id,jobId));
            }
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public async Task<ActionResult> RejectContract(RejectContractViewModel model)
        {
            string[] validationErrors = null;
            if (model.EndReasonId != (long)ContractDenyReasonEnum.Other)
                ModelState.Remove("model.OtherEndReason");
            if (ModelState.IsValid)
            {
                ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
                model.ModifiedByUserId = user.Id;
                await ExecuteFunction(() => new ContractRepository().RejectContract(model));
            }
            else
                validationErrors = ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray();
            return Json(new { result = validationErrors }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ManageContract(long? contractId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return View(await ExecuteFunction(() => new WorkerRepository().GetManageContractScreenData(contractId, user.Id)));
        }

        [HttpPost]
        public async Task<ActionResult> ManageContract(ContractViewModel model)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
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
                TempData[SessionNameConstants.SuccessMessage] = "Contract updated successfully";
                return RedirectToAction("ManageContract", new { contractId = model.ContractId });
            }
            return View(model);
        }
    }
}