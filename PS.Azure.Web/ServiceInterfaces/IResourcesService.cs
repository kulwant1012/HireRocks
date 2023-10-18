using PS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IResourceTypeService
    {
        [OperationContract]
        OperationResult<ResourceTypeItem> GetResourceTypeById(string id);

        [OperationContract]
        OperationResult<ICollection<ResourceTypeItem>> GetResourceTypeByNameStartWith(string nameStartWithString);

        [OperationContract]
        OperationResult<ICollection<ResourceTypeItem>> GetAllResourceTypes();

        [OperationContract]
        OperationResult CreateResourceType(ResourceTypeItem resourceType);

        [OperationContract]
        OperationResult DeleteResourceType(ResourceTypeItem resourceType);
    }

    [ServiceContract]
    public interface IResourceCategoryService
    {
        [OperationContract]
        OperationResult<ResourceCategoryItem> GetResourceCategoryById(string id);

        [OperationContract]
        OperationResult<ICollection<ResourceCategoryItem>> GetResourceCategoriesByTypeId(string typeId);

        [OperationContract]
        OperationResult<ICollection<ResourceCategoryItem>> GetResourceCategoriesByNameStartWith(string nameStartWithString);

        [OperationContract]
        OperationResult<ICollection<ResourceCategoryItem>> GetAllResourceCategories();

        [OperationContract]
        OperationResult CreateResourceCategory(ResourceCategoryItem resourceCategory);

        [OperationContract]
        OperationResult DeleteResourceCategory(ResourceCategoryItem resourceCategory);
    }

    [ServiceContract]
    public interface IResourcesService
    {
        [OperationContract]
        OperationResult<Resource> GetResourceById(string id);


        [OperationContract]
        OperationResult<ICollection<Resource>> GetResourcesByNameStartWith(string nameStartWithString);

        [OperationContract]
        OperationResult<IEnumerable<string>> GetResourcesSearchSuggestions(string nameStartWithString, int suggestionsCount);

        [OperationContract]
        OperationResult<ICollection<Resource>> GetAllResources();

        [OperationContract]
        OperationResult CreateResource(Resource resource);

        [OperationContract]
        OperationResult DeleteResource(Resource resource);
    }
}
