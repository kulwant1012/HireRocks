using System.Reflection;
using PS.Data.Indexes;
using PS.Data.Interfaces;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PS.Data.Entities;

namespace PS.Data.Repositories
{
    public abstract class ResourceRepository<T> : Repository<T>, ISearchRepository where T : class,IEntity
    {
        public abstract IEnumerable<string> GetSearchSuggestions(string nameStartWith, int suggestionsCount);

        //protected ResourceRepository()
        //{
        //    IndexCreation.CreateIndexesAsync(typeof(ResourceTypeIndex).Assembly, DocumentStore);
        //}
    }

    public class ResourceTypeRepository : ResourceRepository<ResourceTypeItem>
    {
        public override IEnumerable<string> GetSearchSuggestions(string nameStartWith, int suggestionsCount)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<ResourceTypeItem, ResourceTypeIndex>().Select(i => i.Name).Take(suggestionsCount);
            }
        }
    }

    public class ResourceCategoryRepository : ResourceRepository<ResourceCategoryItem>
    {
        public override IEnumerable<string> GetSearchSuggestions(string nameStartWith, int suggestionsCount)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<ResourceCategoryItem, ResourceCategoryIndex>().Select(i => i.Name).Take(suggestionsCount);
            }
        }
    }

    public class ResourcesRepository : ResourceRepository<Resource>
    {

        //public ResourcesRepository()
        //{
        //    IndexCreation.CreateIndexesAsync(typeof(ResourceIndex).Assembly, DocumentStore);
        //}

        public override IEnumerable<string> GetSearchSuggestions(string nameStartWith, int suggestionsCount)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Resource, ResourceItemsIndex>().Select(i => i.Name).Take(suggestionsCount);
            }
        }
    }
}
