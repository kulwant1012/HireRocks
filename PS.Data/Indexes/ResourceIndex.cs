using System.Linq.Expressions;
using PS.Data.Entities;
using PS.Data.Interfaces;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Indexes
{
    public class ResourceTypeIndex : AbstractIndexCreationTask<ResourceTypeItem, ResourceTypeIndex>
    {
        public ResourceTypeIndex()
        {
            Map = entities => from entity in entities select new { entity.Name };
        }

        public override string IndexName
        {
            get
            {
                return "ResourceTypes/SearchSuggestions";
            }
        }
    }

    public class ResourceCategoryIndex : AbstractIndexCreationTask<ResourceCategoryItem, ResourceCategoryIndex>
    {
        public ResourceCategoryIndex()
        {
            Map = entities => from entity in entities select new { entity.Name };
        }

        public override string IndexName
        {
            get
            {
                return "ResourceCategoires/SearchSuggestions";
            }
        }
    }

    public class ResourceItemsIndex : AbstractIndexCreationTask<Resource, ResourceItemsIndex>
    {
        public ResourceItemsIndex()
        {
            Map = entities => from entity in entities select new { entity.Name };
        }

        public override string IndexName
        {
            get
            {
                return "ResourceItems/SearchSuggestions";
            }
        }
    }

    public class ResourceIndex : AbstractIndexCreationTask<Resource, ResourceIndex>
    {
        public ResourceIndex()
        {
            Map = entities => from entity in entities select new { entity.Name, entity.ShortDescription, entity.LongDescription };
        }

        public override string IndexName
        {
            get
            {
                return "ResourceItems/SearchSuggestions";
            }
        }
    }
}

