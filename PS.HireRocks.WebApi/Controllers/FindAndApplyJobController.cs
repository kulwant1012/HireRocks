using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS.HireRocks.Data.Helpers;
using PS.HireRocks.Model;
using PS.HireRocks.Data.Repositories;
using System.Threading.Tasks;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Models;
using System.Configuration;
using System.IO;
using System.Web.Http;
using PS.HireRocks.WebApi.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PS.HireRocks.WebApi.Controllers
{
    [Authorize(Roles = RoleConstants.Worker)]
    public class FindAndApplyJobController : BaseController
    {
        public FindAndApplyJobController()
    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public FindAndApplyJobController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        [HttpGet]
        [Authorize]
        [Route("FindJobs")]
        public FindJobScreenViewModel FindJobs()
        {
            FindJobScreenViewModel findJobScreenViewModel = new FindJobScreenViewModel();
            var loggedInUser =  UserManager.FindByIdAsync(User.Identity.GetUserId());            
            findJobScreenViewModel =  new JobRepository().GetFindJobScreenData(User.Identity.GetUserId());            
            return findJobScreenViewModel;
        }

        [HttpGet]
        [Authorize]
        [Route("GetJobsList")]
        public async Task<IHttpActionResult> GetJobsList([FromUri] FindJobFilters findJobFilters)
        {
            var loggedInUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            findJobFilters.JobSubCategoriesIds = findJobFilters.JobSubCategoriesList != null ? string.Join(",", findJobFilters.JobSubCategoriesList) : null;
            findJobFilters.WorkerId = loggedInUser.Id;
            findJobFilters.JobName = findJobFilters.JobName;
            var result = (await ExecuteFunction(() => new JobRepository().GetJobsByFilter(findJobFilters)));
            return Json(result);
        }

        [HttpGet]
        [Authorize]
        [Route("GetJobSubCategories")]
        public async Task<object> GetJobSubCategories(long? jobCategoryId)
        {
            var loggedInUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var findJobScreenViewModel =  FindJobs();            
            if (findJobScreenViewModel != null && jobCategoryId.HasValue)                
                return (new { result = true, data = findJobScreenViewModel.AllJobSubCategoryList.Where(x => x.JobCategoryId == jobCategoryId) });
            return (new { result = false });
        }

        //[HttpGet]
        //public PartialViewResult ApplyForJob()
        //{
        //    return PartialView(PartialViewNames.ApplyJobPartial,new ApplyForJobViewModel());
        //}
  
        [HttpPost]
        [Authorize]
        [Route("ApplyForJob")]
        public async Task<IHttpActionResult> ApplyForJob(ApplyForJobViewModel applyForJobViewModel, IEnumerable<HttpPostedFileBase> attachments)
        {
            ApplicationUser worker = await UserManager.FindByIdAsync(User.Identity.GetUserId());
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
                                attachment.SaveAs(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.AttachmentFolderName]) + fileName);
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
                    return Ok(new { SuccessMessage = "You applied for this job successfully" });               
            }
            return Ok(applyForJobViewModel);
        }      
    }
}