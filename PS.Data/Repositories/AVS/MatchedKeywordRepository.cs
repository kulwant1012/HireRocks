using PS.Data.Entities.AVS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Linq;

namespace PS.Data.Repositories.AVS
{
    public class MatchedKeywordRepository : Repository<MatchedKeyword>, IMatchedKeywordRepository
    {
        public MatchedKeyword AddOrUpdateMatchedKeyword(MatchedKeyword matchedKeyword)
        {
            using (var session = DocumentStore.OpenSession())
            {
                if (string.IsNullOrEmpty(matchedKeyword.Id))
                    matchedKeyword.Id = Guid.NewGuid().ToString();
                session.Store(matchedKeyword);
                session.SaveChanges();
                return matchedKeyword;
            }
        }

        public ICollection<MatchedKeyword> GetMatchedKeywordIds(string[] matchedKeywordIds)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<MatchedKeyword>().Where(x => x.Id.In<string>(matchedKeywordIds)).ToList();
            }
        }
    }
}
