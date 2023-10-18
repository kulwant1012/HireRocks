using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Models;
using PS.HireRocks.Data.Helpers;
using System.Globalization;
using Microsoft.AspNet.Identity;
using System.IO;
using PS.HireRocks.WebApi.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;


namespace PS.HireRocks.WebApi.Controllers
{

    [RoutePrefix("api/Job")]
    public class JobController : BaseController
    {
        public JobController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public JobController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        [HttpGet]
        [Authorize(Roles = RoleConstants.Client)]
        [Route("PostJob")]
        public async Task<PostJobViewModel> PostJob(long? jobId)
        {
            var user =await UserManager.FindByIdAsync(User.Identity.GetUserId());
            PostJobViewModel postJobViewModel = new PostJobViewModel();
            var result = await new JobRepository().GetPostJobScreenData(jobId, user.Id);
            if (!result.IsErrorReturned)
                postJobViewModel = result.Value;
            postJobViewModel.CountriesList = GetCountriesList().ToList();
            return postJobViewModel;
        }

        [HttpGet]
        [Authorize]
        [Route("WorkersBidForJob")]
        public async Task<IHttpActionResult> WorkersBidForJob(long? jobId, string JobTitle)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            ContractViewModel contractViewModel = new ContractViewModel();
            contractViewModel = await ExecuteFunction(() => new JobRepository().GetTimeUnitList());
            return Ok(contractViewModel);
        }

        #region Get Data

        [HttpGet]
        [Authorize]
        [Route("GetJobSubCategories")]
        public async Task<IHttpActionResult> GetJobSubCategories(long? jobId,long ? jobCategoryId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            PostJobViewModel postJobViewModel = new PostJobViewModel();
            var result = await new JobRepository().GetPostJobScreenData(jobId, user.Id);
            if (!result.IsErrorReturned)
                postJobViewModel = result.Value;
            postJobViewModel.CountriesList = GetCountriesList().ToList();

            if (postJobViewModel != null && jobCategoryId.HasValue)
                return Json(new { result = true, data = postJobViewModel.AllJobSubCategoryList.Where(x => x.JobCategoryId == jobCategoryId) });
            return Json(new { result = false });
        }

        [HttpGet]
        [Route("ViewJob")]
        [Authorize]
        public async Task<IHttpActionResult> ViewJob(long? jobId)
        {
            if (jobId.HasValue)
            {
                var result = await new JobRepository().GetJobDetailScreenDataByJobId(jobId);
                if (!result.IsErrorReturned)
                    return Ok(result.Value);
            }
           return BadRequest();
        }

        [HttpGet]
        [Authorize]
        [Route("GetJobs")]
        public async Task<IHttpActionResult> GetJobs()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            List<GetJobsViewModel> jobsList = new List<GetJobsViewModel>();
            if (user != null)
            {
                var result = await new JobRepository().GetJobsByClientId(user.Id);
                if (!result.IsErrorReturned && result.Value != null)
                    jobsList = result.Value;
            }
            return Ok(jobsList);
        }

        [HttpGet]
        [Authorize]
        [Route("GetWorkersBidForJob")]
        public async Task<IHttpActionResult> GetWorkersBidForJob(long? jobId)
        {           
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var result = await ExecuteFunction(() => new JobRepository().GetWorkersBidForJob(jobId,user.Id));
            return Ok(result);
        }

        IEnumerable<System.Web.Mvc.SelectListItem> GetCountriesList()
        {
            List<System.Web.Mvc.SelectListItem> countriesList = new List<System.Web.Mvc.SelectListItem>();
            System.Web.Mvc.SelectListItem country;
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                country = new System.Web.Mvc.SelectListItem { Text = regionInfo.EnglishName, Value = regionInfo.EnglishName };
                if (!countriesList.Exists(x => x.Value == country.Value))
                    countriesList.Add(country);
            }
            return countriesList.OrderBy(x => x.Value);
        }

        [HttpGet]
        [Authorize]
        [Route("GetWorkerBid")]
        public async Task<IHttpActionResult> GetWorkerBid(long jobBidId,string workerId)
        {
            var contractViewModel = await ExecuteFunction(() => new WorkerRepository().GetHireWorkerScreenData(null, workerId, null, jobBidId));           
            return Ok(contractViewModel);
        }


        [HttpGet]
        [Authorize]
        [Route("GetWorkerJobs")]
        public IHttpActionResult GetWorkerJobs()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            List<WorkerJobsViewModel> jobsList = new List<WorkerJobsViewModel>();
            if (user != null)
            {
                var result = new JobRepository().GetJobsByWorkerId(User.Identity.GetUserId(), null);
                jobsList = result;
            }
            return Ok(jobsList);
        }


        #endregion

        #region PostData
        [HttpPost]
        [Route("PostJob")]
        [Authorize]
        public async Task<object> PostJob(PostJobViewModel model)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (model.JobTypeId == 1)
            {
                ModelState.Remove("FixedRate");
            }
            else
            {
                ModelState.Remove("Max_PRF_Rate");
                ModelState.Remove("Min_PRF_Rate");
            }

            if (user == null)
                ModelState.AddModelError(string.Empty, "Please login to post job");
            else
                model.ClientId = user.Id;
            model.SkillRequiredForJobIds = string.Join(",", model.SkillList.Where(x => x.IsSelected).Select(x => x.SkillId));

            if (string.IsNullOrEmpty(model.SkillRequiredForJobIds))
                ModelState.AddModelError(string.Empty, "Select skills from provided options");
            if (ModelState.IsValid)
            {
                List<Task> uploadAttachmentTasksList = new List<Task>();
                if (model.attachments != null)
                    foreach (var attachment in model.attachments)
                    {
                        if (attachment != null)
                        {
                            uploadAttachmentTasksList.Add(Task.Factory.StartNew(() =>
                            {
                                string originalFileName = attachment.FileName;
                                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(originalFileName);
                                attachment.SaveAs(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.AttachmentFolderName]) + uniqueFileName);
                                model.InsertUpdateAttachmentsViewModel.InsertAttachmentsList.Add(new JobAttachmentsViewModel { AttachmentName = uniqueFileName, AttachmentOriginalName = originalFileName });
                            }));
                        }
                    }
                await Task.WhenAll(uploadAttachmentTasksList);
                model.InsertUpdateAttachmentsViewModel.DeleteAttachmentIdsList = model.JobAttachmentsList.Where(x => x.IsDeleted).Select(x => x.JobAttachmentId.Value).ToList();
                model.JobAttachmentsXML = new ConvertObjectToXML().ConvertObjectToXml(model.InsertUpdateAttachmentsViewModel);
                if (!model.JobId.HasValue)
                {
                    model.IsActive = true;
                    model.IsHiringClosed = false;
                }
                var result = await new JobRepository().InsertUpdateJob(model);
                if (!result.IsErrorReturned)
                {
                   return (new { result = true, jobId = model.JobId });
                   
                }
                else
                    return BadRequest("Something went wrong, please try again");
               
            }
            return BadRequest("Model state is not valid");
        }

        [HttpPost]
        [Authorize]
        [Route("AcceptWorkerBid")]
        public async Task<object> AcceptWorkerBid(ContractViewModel model)
        {
            string message = string.Empty;
            string subject = string.Empty;
            long? contractId=null;
            //var hireWorkerScreenData = (ContractViewModel)TempData[SessionNameConstants.ContractSession];
            if (model.JobTypeId == (long)JobTypeEnum.Hourly)
                ModelState.Remove("FixedRate");
            if (model.JobTypeId == (long)JobTypeEnum.Fixed)
            {
                ModelState.Remove("HourlyRate");
                ModelState.Remove("WeeklyHourLimit");
            }
            ModelState.Remove("COntractStatusId");
            if (model.ContractId.HasValue)
                ModelState.AddModelError(string.Empty, "You already hired this person for this job");
            ModelState.Remove("EndReason");
            ModelState.Remove("EndReasonId"); /* --vedit*/
            ModelState.Remove("OtherEndReason");
            ModelState.Remove("WeeklyHourLimit");
            if (ModelState.IsValid)
            {
                var loggedInUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                model.COntractStatusId = ContractStatusConstants.Awaiting;
                model.CreatedModifiedByUserId = loggedInUser.Id;
                contractId = await ExecuteFunction(() => new WorkerRepository().InsertUpdateContract(model));
                subject = "Your bid is accepted";
                message = " has accepted your request for job " + model.JobTitle;
                var contractTemplate = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/Contract" +
                    "Template.html"));
                contractTemplate = contractTemplate.Replace("#WorkerName#", model.FirstName + " " + model.LastName);
                contractTemplate = contractTemplate.Replace("#Message#", User.Identity.GetUserName() + message);
                contractTemplate = contractTemplate.Replace("#JobTitle#", model.JobTitle);
                contractTemplate = contractTemplate.Replace("#EstimatedDuration#", model.EstimatedDuration.Value.ToString());
                contractTemplate = contractTemplate.Replace("#ClientName#", User.Identity.GetUserName());
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
                model.IsSubmitedSuccessfully = true;
                model.TimeUnitsList = model.TimeUnitsList;
                return Ok(new { result = "Request sent to worker for approval!", jobId = model.JobId });
            }
           
            return BadRequest(ModelState);
        }
        #endregion

        #region Update Data

        [HttpDelete]
        [Route("RemoveAttachment")]
        [Authorize]
        public async Task<IHttpActionResult>  RemoveAttachment(long? jobId,long? attachmentId)
        {
            var user = await UserManager .FindByIdAsync(User.Identity.GetUserId());
            PostJobViewModel postJobViewModel = new PostJobViewModel();
            var result = await new JobRepository().GetPostJobScreenData(jobId, user.Id);
            if (!result.IsErrorReturned)
                postJobViewModel = result.Value;          
            if (postJobViewModel != null && postJobViewModel.JobAttachmentsList != null && attachmentId.HasValue)
            {
                var attachment = postJobViewModel.JobAttachmentsList.FirstOrDefault(x => x.JobAttachmentId == attachmentId);
                if (attachment != null)
                {
                    attachment.IsDeleted = true;
                    return Ok(new { Result = true });
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("RemoveAttachment")]
        [Authorize]
        public async Task<IHttpActionResult> DeniedJobRequest(long? jobBidId)
        {
            var result = await ExecuteFunction(() => new JobRepository().JobRequestDenied(jobBidId));
            return Ok(result);
        }    
        #endregion
    }
   
    
}