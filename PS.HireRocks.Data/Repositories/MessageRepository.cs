using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using PS.HireRocks.Model;
using PS.HireRocks.Data.Database;
using PS.HireRocks.Data.Helpers;
using System.Web.Mvc;

namespace PS.HireRocks.Data.Repositories
{
    public class MessageRepository : BaseRepository
    {
        public IEnumerable<SelectListItem> GetClientJobList(string clientId)
        {
            using (var entities = new Entities())
            {
                return entities.GetJobListForMessageScreen(clientId).ToList().Select(x => new SelectListItem { Text = x.JobTitle, Value = x.JobId.ToString() });
            }
        }

        public IEnumerable<SelectListItem> GetWorkerJobList(string workerId)
        {
            using (var entities = new Entities())
            {
                return entities.GetWorkerJobListForMessageScreen(workerId).ToList().Select(x => new SelectListItem { Text = x.JobTitle, Value = x.JobId.ToString() });
            }
        }

        public IEnumerable<GetWorkerViewModel> GetClientWorkerList(long? jobId,string workerId,string clientId)
        {
            using (var entities = new Entities())
            {
                return entities.GetWorkersForMessageScreen(jobId, workerId,clientId).ToList().Select(x => new GetWorkerViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProfileImage = x.ProfilePic,
                    Email = x.Email,
                    WorkerId = x.Id,
                    IsHired = x.ContractId == null ? false : true,
                    UserName=x.UserName
                });
            }
        }

        public IEnumerable<GetWorkerViewModel> GetClientInfo(long jobID)
        {
            using (var entities = new Entities())
            {
                return entities.GetClientInfoByJobId(jobID).ToList().Select(x => new GetWorkerViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProfileImage = x.ProfilePic,
                    Email = x.Email,
                    ClientId = x.Id,
                    UserName=x.UserName
                });
            }
        }

        public void InsertMessage(MessageViewModel model)
        {
            using (var entities = new HireRocks.Data.Database.Entities())
            {
                entities.InsertMessage(model.JobId, model.MessageText, model.MessageFromUserId, model.MessageToUserId);
            }
        }

        public IEnumerable<MessageViewModel> GetMessages(long? jobId, string workerId, string ClientId, string ClientName,string workerName)
            {
                using (var entities = new Entities())
                {
                    return entities.GetMessages(jobId, workerId).ToList().Select(x => new MessageViewModel
                     {
                         JobId = x.JobId,
                         DateTime = x.DateTime.Value.ToString("MM/dd/yyyy hh:mm tt"),
                         MessageFromUserId = x.MessageFromUserId,
                         MessageToUserId = x.MessageToUserId,
                         MessageText = x.MessageText,
                         MessageTemplateClassName = x.MessageFromUserId == ClientId ? "Right" : "Left",
                         MessageUserName = x.MessageFromUserId == ClientId ? ClientName : workerName,
                         MessageBorder = x.IsViewed.HasValue && !x.IsViewed.Value && x.MessageFromUserId != ClientId ? "1px solid orange" : "0"
                     });                 
                }
            }

        public IEnumerable<MessageViewModel> GetWorkerMessages(long? jobId, string workerId, string workerName, string clientName)
        {
            using (var entities = new Entities())
            {
                return entities.GetMessages(jobId, workerId).ToList().Select(x => new MessageViewModel 
                {
                    JobId = x.JobId,
                    DateTime = x.DateTime.Value.ToString("MM/dd/yyyy hh:mm tt"),
                    MessageFromUserId = x.MessageFromUserId,
                    MessageToUserId = x.MessageToUserId,
                    MessageText = x.MessageText,
                    MessageTemplateClassName = x.MessageFromUserId==workerId?"Right":"Left",
                    MessageUserName = x.MessageFromUserId==workerId?workerName:clientName,
                    MessageBorder = x.IsViewed.HasValue && !x.IsViewed.Value && x.MessageFromUserId != workerId ? "1px solid orange" : "0"
                });
            }
        }

        public GetUnreadNotificationAndMessageCountViewModel GetUnreadNotificationAndMessageCount(string userId)
        {
            using (var entities = new Entities())
            {
                return entities.GetUnreadNotificationAndMessageCount(userId).Select(x => new GetUnreadNotificationAndMessageCountViewModel
                {
                    UnreadMessagesCount=x.UnreadMessages,
                    UnreadNotificationsCount=x.UnreadNotifications
                }).FirstOrDefault();
            }
        }

        public void UpdateMessageViewedStatus(string userId,long jobId)
        {
            using (var entities = new Entities())
            {
                entities.UpdateMessageViewedStatus(userId, jobId);
            }
        }

        public GetUnreadNotificationAndMessageCountViewModel GetUnreadMessagesCount(string userId)
        {
            using (var entities = new Entities())
            {
                return entities.GetUnreadMessageCount(userId).Select(x => new GetUnreadNotificationAndMessageCountViewModel { UnreadMessagesCount = x.Value }).FirstOrDefault();
            }
        }
    }
}


    

