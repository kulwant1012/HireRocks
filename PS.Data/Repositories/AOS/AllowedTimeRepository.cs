using PS.Data.Entities.AOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Repositories.AOS
{
    public class AllowedTimeRepository : Repository<AllowedTime>, IAllowedTimeRepository
    {
        public AllowedTime AddOrUpdateAllowedTimeCollection(AllowedTime allowedTime)
        {
            using (var session = DocumentStore.OpenSession())
            {
                if (string.IsNullOrEmpty(allowedTime.Id))
                    allowedTime.Id = Guid.NewGuid().ToString();
                session.Store(allowedTime);
                session.SaveChanges();
                return allowedTime;
            }
        }

        public AllowedTime GetAllowedTimeCollectionById(string collectionId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<AllowedTime>().FirstOrDefault(x => x.Id == collectionId);
            }
        }
    }
}
