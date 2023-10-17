using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PS.HireRocks.Model;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Web.Models;
using PS.HireRocks.Data.Helpers;
using System.Configuration;

namespace PS.HireRocks.Web.Controllers
{
    [Authorize(Roles = RoleConstants.Client)]
    public class FindAndHireWorkerController : BaseController
    {
        #region Get Data

        public async Task<ActionResult> FindWorker()
        {
            var result = await ExecuteFunction(() => new WorkerRepository().GetFindWorkerScreenData());
            return View(result);
        }

        public async Task<ActionResult> GetWorkersList([DataSourceRequest] DataSourceRequest request, FindWorkerFilter findWorkerFilter)
        {
            findWorkerFilter.WorkerName = findWorkerFilter.WorkerName ?? string.Empty;
            findWorkerFilter.CountryNames = findWorkerFilter.CountryNameList != null ? string.Join(",", findWorkerFilter.CountryNameList) : null;
            findWorkerFilter.SkillIds = findWorkerFilter.SkillIdsList != null ? string.Join(",", findWorkerFilter.SkillIdsList) : null;
            var result = await ExecuteFunction(() => new WorkerRepository().FindWorkersByFilter(findWorkerFilter));
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HireWorker(string workerId)
        {
            ViewData["WorkerId"] = workerId;
            return View();
        }

        public async Task<ActionResult> GetContractsGridData([DataSourceRequest] DataSourceRequest request, string workerId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            IEnumerable<ContractsGridViewModel> contractsList = new List<ContractsGridViewModel>();
            if (user != null && !string.IsNullOrEmpty(workerId))
                contractsList = await ExecuteFunction(() => new WorkerRepository().GetContractsGridData(workerId, user.Id));
            return Json(contractsList.ToDataSourceResult(request));
        }

        public async Task<ActionResult> HireWorkerPartial(string workerId, long? contractId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            ContractViewModel contractViewModel = null;
            if (!string.IsNullOrEmpty(workerId) && user != null && !contractId.HasValue || contractId.HasValue && user != null)
                contractViewModel = await ExecuteFunction(() => new WorkerRepository().GetHireWorkerScreenData(user.Id, workerId, contractId));
            TempData[SessionNameConstants.HireWorkerScreenSession] = contractViewModel;
            return PartialView(PartialViewNames.HireWorkerPartialView, contractViewModel);
        }


        public async Task<ActionResult> GetJobsList(string workerId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new WorkerRepository().GetJobListForHireWorkerScreen(workerId, user.Id)),JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Post/Update data
        [HttpPost]
        public async Task<ActionResult> HireWorker(ContractViewModel model)
        {
            var loggedInUser = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            var hireWorkerScreenData = (ContractViewModel)TempData[SessionNameConstants.HireWorkerScreenSession];
            if (!model.COntractStatusId.HasValue)
            {
                ModelState.Remove("COntractStatusId");
                model.COntractStatusId = ContractStatusConstants.Awaiting;
            }
            if (model.JobTypeId == (long)JobTypeEnum.Hourly)
            {
                ModelState.Remove("FixedRate");
                model.FixedRate = null;
                model.HourlyRateFromOrToDate = DateTime.Now;
            }
            if (model.JobTypeId == (long)JobTypeEnum.Fixed)
            {
                ModelState.Remove("HourlyRate");
                ModelState.Remove("WeeklyHourLimit");
                model.HourlyRate = null;
                model.HourlyRateFromOrToDate = null;
            }
            if (model.ContractId.HasValue && model.IsEndingContract)
                ModelState.Remove(model.EndReasonId == (long)ContractEndReasonEnum.Other ? "EndReason" : "OtherEndReason");
            
            if (!model.IsEndingContract)
            {
                ModelState.Remove("UserRatingsViewModel.Comment");
                ModelState.Remove("OtherEndReason");
                ModelState.Remove("EndReason");
                ModelState.Remove("EndReasonId");
            }

            if (ModelState.IsValid)
            {
                if (model.ContractId.HasValue && model.IsEndingContract)
                {
                    model.COntractStatusId = ContractStatusConstants.Closed;
                    model.UserRatingsViewModel.UserId = loggedInUser.Id;
                    if (model.EndReasonId == (long)ContractEndReasonEnum.Other)
                        model.EndReason = model.OtherEndReason;
                }
                if (model.ContractId.HasValue && !model.IsEndingContract) model.COntractStatusId = ContractStatusConstants.Awaiting;
                model.CreatedModifiedByUserId = loggedInUser.Id;
                model.ContractEndDate = model.ContractEndDate ?? DateTime.Now.Date;
                long? contractId = await ExecuteFunction(() => new WorkerRepository().InsertUpdateContract(model));

                if (contractId.HasValue)
                {
                    string successMessage = string.Empty;
                    string message = string.Empty;
                    string subject = string.Empty;

                    if (model.ContractId.HasValue)
                    {
                        successMessage = "Contract updated successfully";
                        message = " has updated following contract";
                        subject = "An existing contract has been updated!";
                    }
                    else
                    {
                        successMessage = "Request sent to worker for approval!";
                        message = " has assigned you new contract";
                        subject = "New contract is assigned!";
                    }
                    TempData[SessionNameConstants.SuccessMessage] = successMessage;
                    var contractTemplate = System.IO.File.ReadAllText(Server.MapPath("~/EmailTemplates/ContractTemplate.html"));
                    contractTemplate = contractTemplate.Replace("#WorkerName#", hireWorkerScreenData.FirstName + " " + hireWorkerScreenData.LastName);
                    contractTemplate = contractTemplate.Replace("#Message#", loggedInUser.FirstName + " " + loggedInUser.LastName + message);
                    contractTemplate = contractTemplate.Replace("#JobTitle#", model.JobTitle);
                    contractTemplate = contractTemplate.Replace("#EstimatedDuration#", model.EstimatedDuration.Value.ToString());
                    contractTemplate = contractTemplate.Replace("#ClientName#", loggedInUser.FirstName + " " + loggedInUser.LastName);
                    if (model.JobTypeId == (long)JobTypeEnum.Hourly)
                    {
                        contractTemplate = contractTemplate.Replace("#RateType#", "Hourly rate");
                        contractTemplate = contractTemplate.Replace("#RateValue#", model.HourlyRate.ToString());
                        contractTemplate = contractTemplate.Replace("#WeeklyHourLimit#", model.WeeklyHourLimit.Value.ToString());
                        contractTemplate = contractTemplate.Replace("#WeeklyHourLimitVisivility#", "block");
                    }
                    if (model.JobTypeId == (long)JobTypeEnum.Fixed)
                    {
                        contractTemplate = contractTemplate.Replace("#RateType#", "Fixed rate");
                        contractTemplate = contractTemplate.Replace("#RateValue#", model.FixedRate.ToString());
                        contractTemplate = contractTemplate.Replace("#WeeklyHourLimitVisivility#", "none");
                    }
                    contractTemplate = contractTemplate.Replace("#VerificationLink#", ConfigurationManager.AppSettings[WebsiteConstants.ServerAddress] + "WorkerContract/ReviewContract?id=" + contractId);

                    await new EmailHelper().SendEmailNotification(hireWorkerScreenData.Email, subject, contractTemplate);
                    return RedirectToAction("HireWorkerPartial", new { workerId = model.WorkerId, contractId = model.ContractId });
                }
                else
                    ModelState.AddModelError(string.Empty, "Please make some changes before update!");
            }
            model.JobsList = hireWorkerScreenData.JobsList;
            model.TimeUnitsList = hireWorkerScreenData.TimeUnitsList;
            model.ContractStatusList = hireWorkerScreenData.ContractStatusList;
            TempData.Keep();
            return PartialView(PartialViewNames.HireWorkerPartialView, model);
        }
        #endregion
    }
}