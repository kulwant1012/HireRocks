using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS.Data;
using Microsoft.AspNet.SignalR;
using PS.Data.Entities.AOS;
using PS.Data.Repositories;

namespace PS.Azure.Web
{
    public class NotificaitonHub : Hub
    {
        NotificationClientsRepository _notificationClientsRepository = new NotificationClientsRepository();
       
        public void SendNotification(Notification notification)
        {
            var clients = _notificationClientsRepository.GetClientByUserId(notification.UserId, "ACS");
            if (clients != null)
            {
                foreach (var client in clients)
                {
                    Clients.Client(client.ConnectionId).NotifyMessage(notification);
                }
            }
        }

        public void GetOnlineUsers()
        {
            var clients = _notificationClientsRepository.GetAllOnlineUsers();
            Clients.Group("AMS").GetConnectedClients(clients);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            var userId = Context.QueryString["userId"].ToString();
            var groupName = Context.QueryString["groupName"].ToString();
            NotificationClients notificationClients = new NotificationClients() { ConnectionId = Context.ConnectionId, UserId = userId, GroupName = groupName };
            _notificationClientsRepository.AddClientToList(notificationClients);
            Groups.Add(Context.ConnectionId, groupName).Wait();
            if (groupName == "ACS")
                Clients.Group("AMS").SendConnectedMessage(userId);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var client = _notificationClientsRepository.GetClientByConnectionId(Context.ConnectionId);
            if (client != null)
            {
                if (client.GroupName == "ACS")
                    Clients.Group("AMS").SendDisconnectedMessage(client.UserId);
                _notificationClientsRepository.RemoveClientFromList(client.ConnectionId);
                Groups.Remove(client.ConnectionId, client.GroupName);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}