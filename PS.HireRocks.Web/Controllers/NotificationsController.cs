using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace PS.HireRocks.Web.Controllers
{
    public class NotificationsController : BaseController
    {
        public ActionResult Notifications()
        {
            return View();
        }

        #region Get Data
        public async Task<ActionResult> GetNotificationsGridData([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<NotificationsViewModel> notificationsList=null;
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (user != null)
                notificationsList = await ExecuteFunction(() => new NotificationRepository().GetNotificationsByUserId(user.Id));
            return Json(notificationsList.ToDataSourceResult(request));
        }
        #endregion

        #region Insert/Update data
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> DeleteNotification([DataSourceRequest] DataSourceRequest request, NotificationsViewModel model)
        {
            if (model != null && model.NotificationId.HasValue)
                await ExecuteFunction(() => new NotificationRepository().DeleteNotification(model.NotificationId.Value));
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateNotificationViewedStatus()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            await ExecuteFunction(() => new NotificationRepository().UpdateNotificationViewedStatus(user.Id));
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetUnreadNotificationsCount()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new NotificationRepository().GetUnreadNotificationsCount(user.Id)), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}