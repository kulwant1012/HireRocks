using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PS.HireRocks.WebApi.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/Notifications")]
    public class NotificationsController : BaseController
    {
        public NotificationsController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public NotificationsController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        #region Get Data

        [HttpGet]
        [Authorize]
        [Route("GetNotificationsGridData")]
        public async Task<IHttpActionResult> GetNotificationsGridData()
        {
            IEnumerable<NotificationsViewModel> notificationsList=null;
            var user =await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
                notificationsList = await ExecuteFunction(() => new NotificationRepository().GetNotificationsByUserId(user.Id));
            return Ok(notificationsList);
        }
        #endregion

        #region Insert/Update data
        [HttpPost]
        [Authorize]
        [Route("DeleteNotification")]
        public async Task<IHttpActionResult> DeleteNotification(NotificationsViewModel model)
        {
            if (model != null && model.NotificationId.HasValue)
                await ExecuteFunction(() => new NotificationRepository().DeleteNotification(model.NotificationId.Value));
            return Ok(model);
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateNotificationViewedStatus")]
        public async Task<IHttpActionResult> UpdateNotificationViewedStatus()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            await ExecuteFunction(() => new NotificationRepository().UpdateNotificationViewedStatus(User.Identity.GetUserId()));
            return Ok(new { result = true });
        }

        [HttpGet]
        [Authorize]
        [Route("GetUnreadNotificationsCount")]
        public async Task<IHttpActionResult> GetUnreadNotificationsCount()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            return Json(await ExecuteFunction(() => new NotificationRepository().GetUnreadNotificationsCount(User.Identity.GetUserId())));
        }
        #endregion
    }
}