using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.Data.Entities.AOS;

namespace PS.Data.Repositories.AOS
{
    public class AllCaptureTimeRepository : Repository<AllCaptureTime>, IAllCaptureTimeRepository
    {

        public AllCaptureTime AddOrUpdateAllCaptureTimeCollection(AllCaptureTime allCaptureTime)
        {
            using (var session = DocumentStore.OpenSession())
            {
                if (string.IsNullOrEmpty(allCaptureTime.Id))
                    allCaptureTime.Id = Guid.NewGuid().ToString();
                session.Store(allCaptureTime);
                session.SaveChanges();
                return allCaptureTime;
            }
        }

        public AllCaptureTime GetAllTimeCollectionById(string collectionId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<AllCaptureTime>().FirstOrDefault(x => x.Id == collectionId);
            }
        }
    }
}
