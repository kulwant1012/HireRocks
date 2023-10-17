using Kendo.Mvc.UI;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using PS.HireRocks.Web.Models;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Data.Repositories;
using System.Threading.Tasks;

namespace PS.HireRocks.Web.Controllers
{
    public class MessageController : BaseController
    {
        public ActionResult MyMessages()
        {
            return View();
        }

        public async Task<ActionResult> GetWorkersList([DataSourceRequest] DataSourceRequest request, long? jobId, string workerId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json((await ExecuteFunction(() => new MessageRepository().GetClientWorkerList(jobId, workerId, user.Id))).ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetClientInfo([DataSourceRequest] DataSourceRequest request, long jobId)
        {
            IEnumerable<GetWorkerViewModel> ClientInfo = new List<GetWorkerViewModel>();
            if (jobId != null)
                ClientInfo = await ExecuteFunction(() => new MessageRepository().GetClientInfo(jobId));
            return Json(ClientInfo.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetJobList()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new MessageRepository().GetClientJobList(user.Id)), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetWorkerJobList()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new MessageRepository().GetWorkerJobList(user.Id)), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetMessageList([DataSourceRequest] DataSourceRequest request, long? jobId, string workerId, string workerName)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            IEnumerable<MessageViewModel> messagesList = new List<MessageViewModel>();
            if (jobId.HasValue && !string.IsNullOrEmpty(workerId))
            {
                messagesList = await ExecuteFunction(() => new MessageRepository().GetMessages(jobId, workerId, user.Id, user.FirstName, workerName));
            }
            return Json(messagesList.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetWorkerMessageList([DataSourceRequest] DataSourceRequest request, long? jobId, string clientName)
        {
            ApplicationUser worker = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            IEnumerable<MessageViewModel> messagesList = new List<MessageViewModel>();
            if (jobId.HasValue && worker != null)
            {
                messagesList = await ExecuteFunction(() => new MessageRepository().GetWorkerMessages(jobId, worker.Id, worker.FirstName, clientName));
            }
            return Json(messagesList.ToDataSourceResult(request));
        }


        [HttpPost]
        public async Task<ActionResult> InsertMessage(MessageViewModel model)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (user != null && !string.IsNullOrEmpty(model.MessageText))
            {
                model.MessageFromUserId = user.Id;
                await ExecuteFunction(() => new MessageRepository().InsertMessage(model));
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateMessageViewedStatus(long? jobId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (jobId.HasValue && user != null)
                await ExecuteFunction(() => new MessageRepository().UpdateMessageViewedStatus(user.Id, jobId.Value));
            return Json(new { result=true},JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetUnreadMessageCount()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new MessageRepository().GetUnreadMessagesCount(user.Id)), JsonRequestBehavior.AllowGet);
        }
    }
}