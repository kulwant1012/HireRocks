using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS.HireRocks.WebApi.Models;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.Data.Repositories;
using System.Threading.Tasks;
using PS.HireRocks.WebApi.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/Message")]
    public class MessageController : BaseController
    {
        public MessageController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public MessageController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }


        [HttpGet]
        [Authorize]
        [Route("GetWorkersList")]
        public async Task<IHttpActionResult> GetWorkersList(long? jobId, string workerId)
        {
            var user =await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return Json((await ExecuteFunction(() => new MessageRepository().GetClientWorkerList(jobId, workerId, user.Id))));
        }

        [HttpGet]
        [Authorize]
        [Route("GetClientInfo")]
        public async Task<IHttpActionResult> GetClientInfo(long jobId)
        {
            IEnumerable<GetWorkerViewModel> ClientInfo = new List<GetWorkerViewModel>();
            if (jobId != null)
                ClientInfo = await ExecuteFunction(() => new MessageRepository().GetClientInfo(jobId));
            return Ok(ClientInfo);
        }

        [HttpGet]
        [Authorize]
        [Route("GetJobList")]
        public async Task<IHttpActionResult> GetJobList()
        {
            var user = await UserManager .FindByIdAsync(User.Identity.GetUserId());
            return Json(await ExecuteFunction(() => new MessageRepository().GetClientJobList(user.Id)));
        }

        [HttpGet]
        [Authorize]
        [Route("GetWorkerJobList")]
        public async Task<IHttpActionResult> GetWorkerJobList()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return Json(await ExecuteFunction(() => new MessageRepository().GetWorkerJobList(user.Id)));
        }

        [HttpGet]
        [Authorize]
        [Route("GetMessageList")]
        public async Task<IHttpActionResult> GetMessageList(long? jobId, string workerId, string workerName)
        {
            var user =await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<MessageViewModel> messagesList = new List<MessageViewModel>();
            if (jobId.HasValue && !string.IsNullOrEmpty(workerId))
            {
                messagesList = await ExecuteFunction(() => new MessageRepository().GetMessages(jobId, workerId, user.Id, User.Identity.GetUserName(), workerName));
            }
            return Ok(messagesList);
        }

        [HttpGet]
        [Authorize]
        [Route("GetWorkerMessageList")]
        public async Task<IHttpActionResult> GetWorkerMessageList(long? jobId, string clientName)
        {
            var worker =await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<MessageViewModel> messagesList = new List<MessageViewModel>();
            if (jobId.HasValue && worker != null)
            {
                messagesList = await ExecuteFunction(() => new MessageRepository().GetWorkerMessages(jobId, worker.Id, User.Identity.GetUserName(), clientName));
            }
            return Ok(messagesList);
        }

        [HttpPost]
        [Authorize]
        [Route("InsertMessage")]
        public async Task<IHttpActionResult> InsertMessage(MessageViewModel model)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null && !string.IsNullOrEmpty(model.MessageText))
            {
                model.MessageFromUserId = user.Id;
                await ExecuteFunction(() => new MessageRepository().InsertMessage(model));
                return Ok(new { result = true });
            }
            return BadRequest("Not Inserted");
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateMessageViewedStatus")]
        public async Task<IHttpActionResult> UpdateMessageViewedStatus(long? jobId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (jobId.HasValue && user != null)
                await ExecuteFunction(() => new MessageRepository().UpdateMessageViewedStatus(user.Id, jobId.Value));
            return Ok(new { result = true });
        }

        [HttpGet]
        [Authorize]
        [Route("GetUnreadMessageCount")]
        public async Task<IHttpActionResult> GetUnreadMessageCount()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return Json(await ExecuteFunction(() => new MessageRepository().GetUnreadMessagesCount(user.Id)));
        }
    }
}