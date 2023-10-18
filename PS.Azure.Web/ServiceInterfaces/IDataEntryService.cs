using System.Threading.Tasks;
using PS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web.ServiceInterfaces
{
    [ServiceContract]
    public interface IDataEntryService
    {
        [OperationContract]
        OperationResult<Resource> AddOrUpdateResource(Resource resource);

        [OperationContract]
        OperationResult<List<Resource>> GetResources(string searchText);

        [OperationContract]
        OperationResult DeleteResourceEntry(string id);

        [OperationContract]
        OperationResult<List<Company>> GetCompanyByName(string searchText);

        [OperationContract]
        OperationResult<Company> AddOrUpdateCompany(Company company);

        [OperationContract]
        OperationResult DeleteCompanyEntry(string id);

        [OperationContract]
        OperationResult<List< Brand>> AddBrand(List<Brand>  brand);

        //[OperationContract]
        //OperationResult<AddMediaFile> UploadMedia(AddMediaFile addMediaFile);

        //[OperationContract]
        //OperationResult RemoveMedia(string id);

        [OperationContract]
        OperationResult<string> ShowData(string value);
    }
}
