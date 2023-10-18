using PS.Data.Entities.AOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Linq;

namespace PS.Data.Repositories.AOS
{
    public class KeywordDictionaryRepository : Repository<KeywordDictionary>, IKeywordDictionaryRepository
    {
        public KeywordDictionary AddOrUpdateKeywordDictionary(KeywordDictionary keywordDictionary)
        {
            using (var session = DocumentStore.OpenSession())
            {
                if (string.IsNullOrEmpty(keywordDictionary.Id))
                    keywordDictionary.Id = Guid.NewGuid().ToString();
                session.Store(keywordDictionary);
                session.SaveChanges();
                return keywordDictionary;
            }
        }

        public ICollection<KeywordDictionary> GetKeywordDictionariesByIds(string[] dictionaryIds)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<KeywordDictionary>().Where(x => x.Id.In<string>(dictionaryIds)).ToList();
            }
        }

        public ICollection<KeywordDictionary> GetKeywordDictionaries()
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<KeywordDictionary>().ToList();
            }
        }
    }
}
