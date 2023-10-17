using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PS.HireRocks.Web.Hubs
{
    public class MessageHub : Hub
    {
        public void SendNewMessageNotification(string receiverUserName)
        {
            Clients.Group(receiverUserName).newMessageReceived();
        }

        public void SendNewNotification(string receiverUserName)
        {
            if (!string.IsNullOrEmpty(receiverUserName))
                Clients.Group(receiverUserName).newNotificationReceived();
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Groups.Add(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Groups.Remove(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnDisconnected(stopCalled);
        }
    }
}