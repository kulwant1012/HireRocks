using PS.Data.Entities.AOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Repositories
{
    public class NotificationClientsRepository : Repository<NotificationClients>
    {
        public void AddClientToList(NotificationClients notificationClients)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(notificationClients);
                session.SaveChanges();
            }
        }

        public void RemoveClientFromList(string connectionId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var client = session.Query<NotificationClients>().FirstOrDefault(x => x.ConnectionId == connectionId);
                session.Delete(client);
                session.SaveChanges();
            }
        }

        public NotificationClients GetClientByConnectionId(string connectionId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<NotificationClients>().FirstOrDefault(x => x.ConnectionId == connectionId);
            }
        }

        public List<NotificationClients> GetClientByUserId(string userId,string groupName)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<NotificationClients>().Where(x => x.UserId == userId && x.GroupName == groupName).ToList();
            }
        }

        public List<string> GetAllOnlineUsers()
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<NotificationClients>().Where(x => x.GroupName == "ACS").Select(x => x.UserId).ToList();
            }
        }
    }
}
