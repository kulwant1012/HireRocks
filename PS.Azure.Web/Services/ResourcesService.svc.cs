using PS.Azure.Web.Services;
using PS.Data.Entities;
using PS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web
{
    /// <summary>
    /// Resource type service
    /// </summary>
    public partial class PSService : IResourceTypeService
    {
        public OperationResult<ResourceTypeItem> GetResourceTypeById(string id)
        {
            return TryInvoke(() => _resourceTypeRepository.GetById(id));
        }

        public OperationResult<ICollection<ResourceTypeItem>> GetResourceTypeByNameStartWith(string nameStartWithString)
        {
            return TryInvoke(() => _resourceTypeRepository.Search(i => i.Name.ToLower().StartsWith(nameStartWithString)));
        }

        public OperationResult<ICollection<ResourceTypeItem>> GetAllResourceTypes()
        {
            return TryInvoke(() => _resourceTypeRepository.GetAll());
        }

        public OperationResult CreateResourceType(ResourceTypeItem resourceType)
        {
            return TryInvoke(() => _resourceTypeRepository.InsertOrUpdate(resourceType));
        }

        public OperationResult DeleteResourceType(ResourceTypeItem resourceType)
        {
            return TryInvoke(() => _resourceTypeRepository.Delete(resourceType.Id));
        }
    }

    /// <summary>
    /// Resource categories service
    /// </summary>
    public partial class PSService : IResourceCategoryService
    {
        public OperationResult<ResourceCategoryItem> GetResourceCategoryById(string id)
        {
            return TryInvoke(() => _resourceCategoryRepository.GetById(id));
        }

        public OperationResult<ICollection<ResourceCategoryItem>> GetResourceCategoriesByNameStartWith(string nameStartWithString)
        {
            return
                TryInvoke(
                    () => _resourceCategoryRepository.Search(i => i.Name.ToLower().StartsWith(nameStartWithString)));
        }

        public OperationResult<ICollection<ResourceCategoryItem>> GetAllResourceCategories()
        {
            return TryInvoke(() =>
                {
                    var result = _resourceCategoryRepository.GetAll();
                    return result;
                });
        }

        public OperationResult CreateResourceCategory(ResourceCategoryItem resourceCategory)
        {
            return TryInvoke(() => _resourceCategoryRepository.InsertOrUpdate(resourceCategory));
        }

        public OperationResult DeleteResourceCategory(ResourceCategoryItem resourceCategory)
        {
            return TryInvoke(() => _resourceCategoryRepository.Delete(resourceCategory.Id));
        }

        public OperationResult<ICollection<ResourceCategoryItem>> GetResourceCategoriesByTypeId(string typeId)
        {
            return TryInvoke(() => _resourceCategoryRepository.Search(i => i.TypeId == typeId));
        }
    }

    /// <summary>
    /// Resources service
    /// </summary>
    public partial class PSService : IResourcesService
    {

        public OperationResult<Resource> GetResourceById(string id)
        {
            return TryInvoke(() => _resourceRepository.GetById(id));
        }

        public OperationResult<ICollection<Resource>> GetResourcesByNameStartWith(string nameStartWithString)
        {
            return TryInvoke(() => _resourceRepository.Search(i => i.Name.ToLower().StartsWith(nameStartWithString)));
        }

        public OperationResult<ICollection<Resource>> GetAllResources()
        {
            return TryInvoke(() => _resourceRepository.GetAll());
        }

        public OperationResult CreateResource(Resource resource)
        {
            return TryInvoke(() => _resourceRepository.InsertOrUpdate(resource));
        }

        public OperationResult DeleteResource(Resource resource)
        {
            return TryInvoke(() => _resourceRepository.Delete(resource.Id));
        }

        public OperationResult<IEnumerable<string>> GetResourcesSearchSuggestions(string nameStartWithString, int suggestionsCount)
        {
            return TryInvoke(() => _resourceRepository.GetSearchSuggestions(nameStartWithString, suggestionsCount));
        }
    }
}
