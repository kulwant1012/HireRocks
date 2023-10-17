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
    public class JobController : BaseController
    {
        public ActionResult MyJobs()
        {
            return View();
        }

        public ActionResult WorkerJobs()
        {
            return View();
        }

        [Authorize(Roles=RoleConstants.Client)]
        public async Task<ActionResult> PostJob(long? jobId)
        {
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            PostJobViewModel postJobViewModel = new PostJobViewModel();
            var result = await new JobRepository().GetPostJobScreenData(jobId, user.Id);
            if (!result.IsErrorReturned)
                postJobViewModel = result.Value;
            postJobViewModel.CountriesList = GetCountriesList().ToList();
            TempData[SessionNameConstants.PostJobViewModelSession] = postJobViewModel;
            return View(postJobViewModel);
        }

        public async Task<ActionResult> WorkersBidForJob(long? jobId, string JobTitle)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            ViewBag.JobTitle = JobTitle;
            ContractViewModel contractViewModel = new ContractViewModel();
            contractViewModel = await ExecuteFunction(() => new JobRepository().GetTimeUnitList());
            return View(contractViewModel);
        }

        #region Get Data

        [HttpGet]
        public JsonResult GetJobSubCategories(long ? jobCategoryId)
        {
            var postJobViewModel = (PostJobViewModel)TempData[SessionNameConstants.PostJobViewModelSession];
            TempData[SessionNameConstants.PostJobViewModelSession] = postJobViewModel;
            if (postJobViewModel != null && jobCategoryId.HasValue)
                return Json(new { result = true, data = postJobViewModel.AllJobSubCategoryList.Where(x => x.JobCategoryId == jobCategoryId) }, JsonRequestBehavior.AllowGet);
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewJob(long? jobId)
        {
            if (jobId.HasValue)
            {
                var result = await new JobRepository().GetJobDetailScreenDataByJobId(jobId);
                if (!result.IsErrorReturned)
                    return PartialView(PartialViewNames.ViewJobPartialView, result.Value);
            }
            return PartialView(PartialViewNames.ViewJobPartialView, new ViewJobViewModel());
        }

        public async Task<ActionResult> GetJobs([DataSourceRequest] DataSourceRequest request)
        {
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            List<GetJobsViewModel> jobsList = new List<GetJobsViewModel>();
            if (user != null)
            {
                var result = await new JobRepository().GetJobsByClientId(user.Id);
                if (!result.IsErrorReturned && result.Value != null)
                    jobsList = result.Value;
            }
            return Json(jobsList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetWorkersBidForJob([DataSourceRequest] DataSourceRequest request, long? jobId)
        {
            // var jobId=(long)TempData[SessionNameConstants.WorkersBidForJobJobId];
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            var result = await ExecuteFunction(() => new JobRepository().GetWorkersBidForJob(jobId,user.Id));
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        IEnumerable<SelectListItem> GetCountriesList()
        {
            List<SelectListItem> countriesList = new List<SelectListItem>();
            SelectListItem country;
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                country = new SelectListItem { Text = regionInfo.EnglishName, Value = regionInfo.EnglishName };
                if (!countriesList.Exists(x => x.Value == country.Value))
                    countriesList.Add(country);
            }
            return countriesList.OrderBy(x => x.Value);
        }

        public async Task<ActionResult> GetWorkerBid(long jobBidId,string workerId)
        {
            var contractViewModel = await ExecuteFunction(() => new WorkerRepository().GetHireWorkerScreenData(null, workerId, null, jobBidId));
            TempData[SessionNameConstants.ContractSession] = contractViewModel;
            return PartialView(PartialViewNames.HireWorkerPartialView, contractViewModel);
        }


        public ActionResult GetWorkerJobs([DataSourceRequest] DataSourceRequest request)
        {
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            List<WorkerJobsViewModel> jobsList = new List<WorkerJobsViewModel>();
            if (user != null)      
            {
                var result = new JobRepository().GetJobsByWorkerId(user.Id,null);
                jobsList = result;
            }
            return Json(jobsList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        } 

     

        #endregion

        #region PostData
        [HttpPost]
        public async Task<ActionResult> PostJob(PostJobViewModel model, List<HttpPostedFileBase> attachments)
        {
            PostJobViewModel postJobViewModel = (PostJobViewModel)TempData[SessionNameConstants.PostJobViewModelSession];
            TempData[SessionNameConstants.PostJobViewModelSession] = postJobViewModel;
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];

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
                if (attachments != null)
                    foreach (var attachment in attachments)
                    {
                        if (attachment != null)
                        {
                            uploadAttachmentTasksList.Add(Task.Factory.StartNew(() =>
                            {
                                string originalFileName = attachment.FileName;
                                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(originalFileName);
                                attachment.SaveAs(Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.AttachmentFolderName]) + uniqueFileName);
                                model.InsertUpdateAttachmentsViewModel.InsertAttachmentsList.Add(new JobAttachmentsViewModel { AttachmentName = uniqueFileName, AttachmentOriginalName = originalFileName });
                            }));
                        }
                    }
                await Task.WhenAll(uploadAttachmentTasksList);
                model.InsertUpdateAttachmentsViewModel.DeleteAttachmentIdsList = postJobViewModel.JobAttachmentsList.Where(x => x.IsDeleted).Select(x => x.JobAttachmentId.Value).ToList();
                model.JobAttachmentsXML = new ConvertObjectToXML().ConvertObjectToXml(model.InsertUpdateAttachmentsViewModel);
                if (!model.JobId.HasValue)
                {
                    model.IsActive = true;
                    model.IsHiringClosed = false;
                }
                var result = await new JobRepository().InsertUpdateJob(model);
                if (!result.IsErrorReturned)
                {
                    if (!model.JobId.HasValue)
                    {
                        TempData.Remove(SessionNameConstants.PostJobViewModelSession);
                        TempData[SessionNameConstants.SuccessMessage] = "Job posted successfully";
                    }
                    else
                        TempData[SessionNameConstants.SuccessMessage] = "Job updated successfully";
                    return RedirectToAction("PostJob", new { jobId = model.JobId });
                }
                else
                    ModelState.AddModelError(string.Empty, "Something went wrong please try again");
            }
            if (postJobViewModel != null)
            {
                model.ExperienceLevelList = postJobViewModel.ExperienceLevelList;
                model.JobCategoryList = postJobViewModel.JobCategoryList;
                model.CountriesList = postJobViewModel.CountriesList;
                if (model.JobCategoryId.HasValue)
                    model.JobSubCategoryList = postJobViewModel.AllJobSubCategoryList.Where(x => x.JobCategoryId == model.JobCategoryId).Select(x => new SelectListItem { Text = x.SubCategoryName, Value = x.JobSubCategoryId.ToString() }).ToList();
                model.JobTypeId = postJobViewModel.JobTypeId;
                model.TimeUnits = postJobViewModel.TimeUnits;
                model.WorkerTypeList = postJobViewModel.WorkerTypeList;
                model.JobAttachmentsList.Where(x => !x.IsDeleted);
            }
            return View(model);
        }

        public async Task<ActionResult> AcceptWorkerBid(ContractViewModel model)
        {
            string message = string.Empty;
            string subject = string.Empty;
            long? contractId=null;
            long? notification = null;
            var hireWorkerScreenData = (ContractViewModel)TempData[SessionNameConstants.ContractSession];
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
                ApplicationUser loggedInUser = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
                model.COntractStatusId = ContractStatusConstants.Awaiting;
                model.CreatedModifiedByUserId = loggedInUser.Id;
                contractId = await ExecuteFunction(() => new WorkerRepository().InsertUpdateContract(model));
                notification = await ExecuteFunction(() => new WorkerRepository().InsertNotification(contractId,model,loggedInUser));
                subject = "Your bid is accepted";
                message = " has accepted your request for job " + hireWorkerScreenData.JobTitle;
                var contractTemplate = System.IO.File.ReadAllText(Server.MapPath("~/EmailTemplates/Contract" +
                    "Template.html"));
                contractTemplate = contractTemplate.Replace("#WorkerName#", hireWorkerScreenData.FirstName + " " + hireWorkerScreenData.LastName);
                contractTemplate = contractTemplate.Replace("#Message#", loggedInUser.FirstName + " " + loggedInUser.LastName + message);
                contractTemplate = contractTemplate.Replace("#JobTitle#", hireWorkerScreenData.JobTitle);
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
                ViewData[SessionNameConstants.SuccessMessage] = "Request sent to worker for approval on email!";
                model.IsSubmitedSuccessfully = true;
            }
            model.TimeUnitsList = hireWorkerScreenData.TimeUnitsList;
            TempData.Keep();
            return PartialView(PartialViewNames.HireWorkerPartialView, model);
        }
        #endregion

        #region Update Data
        public JsonResult RemoveAttachment(long? attachmentId)
        {
            PostJobViewModel postJobViewModel = (PostJobViewModel)TempData[SessionNameConstants.PostJobViewModelSession];
            if (postJobViewModel != null && postJobViewModel.JobAttachmentsList != null && attachmentId.HasValue)
            {
                var attachment = postJobViewModel.JobAttachmentsList.FirstOrDefault(x => x.JobAttachmentId == attachmentId);
                if (attachment != null)
                {
                    attachment.IsDeleted = true;
                    TempData[SessionNameConstants.PostJobViewModelSession] = postJobViewModel;
                    return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeniedJobRequest(long? jobBidId)
        {
            var result = await ExecuteFunction(() => new JobRepository().JobRequestDenied(jobBidId));
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult failed()
        {
            return View();
        }
        #endregion
    }
   
    
}