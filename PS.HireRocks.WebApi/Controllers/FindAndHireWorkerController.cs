using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;
using PS.HireRocks.Model;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Models;
using PS.HireRocks.Data.Helpers;
using System.Configuration;
using PS.HireRocks.WebApi.Controllers;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PS.HireRocks.WebApi.Controllers
{

    [RoutePrefix("api/FindAndHireWorker")]
    [Authorize(Roles = RoleConstants.Client)]
    public class FindAndHireWorkerController : BaseController
    {

        public FindAndHireWorkerController()
     : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public FindAndHireWorkerController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }


        [HttpGet]
        [Authorize]
        [Route("Findworker")]
        public async Task<IHttpActionResult> FindWorker()
        {
            var result = await ExecuteFunction(() => new WorkerRepository().GetFindWorkerScreenData());
            return Ok(result);
        }


        [HttpGet]
        [Authorize]
        [Route("GetWorkersList")]
        public async Task<IHttpActionResult> GetWorkersList([FromUri]  FindWorkerFilter findWorkerFilter)
        {
            findWorkerFilter.WorkerName = findWorkerFilter.WorkerName ?? string.Empty;
            findWorkerFilter.CountryNames = findWorkerFilter.CountryNameList != null ? string.Join(",", findWorkerFilter.CountryNameList) : null;
            findWorkerFilter.SkillIds = findWorkerFilter.SkillIdsList != null ? string.Join(",", findWorkerFilter.SkillIdsList) : null;
            var result = await ExecuteFunction(() => new WorkerRepository().FindWorkersByFilter(findWorkerFilter));
            return Ok(result);
        }

        //public ActionResult HireWorker(string workerId)
        //{
        //    ViewData["WorkerId"] = workerId;
        //    return View();
        //}

        [HttpGet]
        [Authorize]
        [Route("GetContractsGridData")]
        public async Task<IHttpActionResult> GetContractsGridData(string workerId)
        {
            var user  =await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<ContractsGridViewModel> contractsList = new List<ContractsGridViewModel>();
            if (user != null && !string.IsNullOrEmpty(workerId))
                contractsList = await ExecuteFunction(() => new WorkerRepository().GetContractsGridData(workerId, user.Id));
            return Ok(contractsList);
        }


        [HttpGet]
        [Authorize]
        [Route("HireWorkerPartial")]
        public async Task<IHttpActionResult> HireWorkerPartial(string workerId, long? contractId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            ContractViewModel contractViewModel = null;
            if (!string.IsNullOrEmpty(workerId) && user != null && !contractId.HasValue || contractId.HasValue && user != null)
                contractViewModel = await ExecuteFunction(() => new WorkerRepository().GetHireWorkerScreenData(user.Id, workerId, contractId));

            return Ok(contractViewModel);
        }

        [HttpGet]
        [Authorize]
        [Route("GetJobsList")]
        public async Task<IHttpActionResult> GetJobsList(string workerId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var result = new WorkerRepository().GetJobListForHireWorkerScreen(workerId, user.Id);
            return Ok(result);
        }


        [HttpPost]
        [Authorize]
        [Route("hireworker")]
        public async Task<IHttpActionResult> HireWorker(ContractViewModel model)
        {
            var loggedInUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
           
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
                  
                    var contractTemplate = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/ContractTemplate.html"));
                    contractTemplate = contractTemplate.Replace("#WorkerName#", model.FirstName + " " + model.LastName);
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

                    await new EmailHelper().SendEmailNotification(model.Email, subject, contractTemplate);
                    return Ok(new { SuccessMessage = successMessage, workerId = model.WorkerId, contractId = model.ContractId });
                }
                else
                    return BadRequest("Please make some changes before update!");
            }
            model.JobsList = model.JobsList;
            model.TimeUnitsList = model.TimeUnitsList;
            model.ContractStatusList = model.ContractStatusList;
            return Ok(model);
        }      
    }
}