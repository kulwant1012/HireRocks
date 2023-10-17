using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using PS.HireRocks.Data.Helpers;
using PS.HireRocks.Model;
using PS.HireRocks.Data.Repositories;
using System.Threading.Tasks;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Web.Models;
using System.Configuration;
using System.IO;


namespace PS.HireRocks.Web.Controllers
{
    [Authorize(Roles = RoleConstants.Worker)]
    public class FindAndApplyJobController : BaseController
    {
       
        public async Task<ActionResult> FindJobs()
        {
            FindJobScreenViewModel findJobScreenViewModel = new FindJobScreenViewModel();
            ApplicationUser loggedInUser = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            findJobScreenViewModel = await ExecuteFunction(() => new JobRepository().GetFindJobScreenData(loggedInUser.Id));
            TempData[SessionNameConstants.FindJobScreenViewModel] = findJobScreenViewModel;
            return View(findJobScreenViewModel);
        }

        #region Get data
        public async Task<ActionResult> GetJobsList([DataSourceRequest] DataSourceRequest request, FindJobFilters findJobFilters)
        {
            var loggedInUser = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            findJobFilters.JobSubCategoriesIds = findJobFilters.JobSubCategoriesList != null ? string.Join(",", findJobFilters.JobSubCategoriesList) : null;
            findJobFilters.WorkerId = loggedInUser.Id;
            findJobFilters.JobName = findJobFilters.JobName;
            var result = (await ExecuteFunction(() => new JobRepository().GetJobsByFilter(findJobFilters))).ToDataSourceResult(request);
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetJobSubCategories(long? jobCategoryId)
        {
            var findJobScreenViewModel = (FindJobScreenViewModel)TempData[SessionNameConstants.FindJobScreenViewModel];
            TempData[SessionNameConstants.FindJobScreenViewModel] = findJobScreenViewModel;
            if (findJobScreenViewModel != null && jobCategoryId.HasValue)
                return Json(new { result = true, data = findJobScreenViewModel.AllJobSubCategoryList.Where(x => x.JobCategoryId == jobCategoryId) }, JsonRequestBehavior.AllowGet);
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult ApplyForJob()
        {
            return PartialView(PartialViewNames.ApplyJobPartial,new ApplyForJobViewModel());
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult> ApplyForJob(ApplyForJobViewModel applyForJobViewModel, IEnumerable<HttpPostedFileBase> attachments)
        {
            ApplicationUser worker = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (worker != null && ModelState.IsValid)
            {
                applyForJobViewModel.WorkerId = worker.Id;
                List<Task> uploadAttachmentTasksList = new List<Task>();
                List<JobAttachmentsViewModel> jobBidAttachments = new List<JobAttachmentsViewModel>();
                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        if (attachment != null)
                        {
                            uploadAttachmentTasksList.Add(Task.Factory.StartNew(() =>
                            {
                                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);
                                string originalFileName = attachment.FileName;
                                attachment.SaveAs(Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.AttachmentFolderName]) + fileName);
                                jobBidAttachments.Add(new JobAttachmentsViewModel { AttachmentOriginalName = originalFileName, AttachmentName = fileName });
                            }));
                        }
                    }
                }
                await Task.WhenAll(uploadAttachmentTasksList);
                applyForJobViewModel.ApplyJobAttachmentsXML = new ConvertObjectToXML().ConvertObjectToXml(jobBidAttachments);
                applyForJobViewModel.UserName = worker.FirstName + " " + worker.LastName;
                if (!await ExecuteFunction(() => new ApplyJobRepository().ApplyJob(applyForJobViewModel)))
                    ModelState.AddModelError(string.Empty, "You already applied for this job");
                else
                    ViewData["Success"] = "You applied for this job successfully";
            }
            return PartialView(PartialViewNames.ApplyJobPartial, applyForJobViewModel);
        }
        #endregion
    }
}