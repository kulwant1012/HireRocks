using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using PS.Azure.Web.ServiceInterfaces;
using PS.Data.Entities;
using PS.Data.Repositories;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Transactions;

namespace PS.Azure.Web
{
    public partial class PSService : IDataEntryService
    {
        public OperationResult<Resource> AddOrUpdateResource(Resource resource)
        {
            return TryInvoke(() =>
                {
                    if (string.IsNullOrEmpty(resource.Id))
                        resource.Id = Guid.NewGuid().ToString();
                    else
                    {
                        List<string> fileNames = new List<string>();
                        if (resource.MediaUrlList != null)
                        {
                            foreach (var item in resource.MediaUrlList.ToList())
                            {
                                fileNames.Add(Path.GetFileName(item.Replace("/", "\\")));
                            }
                            resource.MediaUrlList = fileNames.ToArray();
                            fileNames.Clear();
                        }
                        else
                        {
                            resource.MediaUrlList = null;
                        }

                        if (resource.VideoUrlList != null)
                        {
                            foreach (var item in resource.VideoUrlList.ToList())
                            {
                                fileNames.Add(Path.GetFileName(item.Replace("/", "\\")));
                            }
                            resource.VideoUrlList = fileNames.ToArray();
                            fileNames.Clear();
                        }

                        else
                        {
                            resource.VideoUrlList = null;
                        }
                    }
                    _resourcesRepository.InsertOrUpdate(resource);
                    return resource;
                });
        }

        public OperationResult<List<Resource>> GetResources(string searchText)
        {
            return TryInvoke(() =>
                {
                    var serverPath = _resourceRepository.GetDatabaseName();
                    var lowerSearchText = searchText.ToLower();
                    var result = new List<Resource>();
                    result.AddRange(_resourcesRepository.SearchAnalyze(i => i.Name, lowerSearchText).ToList());
                    result.AddRange(_resourcesRepository.SearchAnalyze(i => i.ShortDescription, lowerSearchText).ToList());
                    result.AddRange(_resourcesRepository.SearchAnalyze(i => i.LongDescription, lowerSearchText).ToList());
                    result.AddRange(_resourcesRepository.Search(i => i.Name.StartsWith(lowerSearchText)
                       || i.LongDescription.StartsWith(lowerSearchText)
                       || i.LongDescription.StartsWith(lowerSearchText)).ToList());

                    foreach (Resource resource in result)
                    {
                        if (resource.MediaUrlList != null)
                        {
                            resource.MediaUrlList = (resource.MediaUrlList != null ? (from imageUrl in resource.MediaUrlList
                                                                                      select serverPath + imageUrl) : null).ToArray();
                        }
                        if (resource.VideoUrlList != null)
                        {
                            resource.VideoUrlList = (resource.VideoUrlList != null ? (from videoUrl in resource.VideoUrlList
                                                                                      select serverPath + videoUrl) : null).ToArray();
                        }
                    }
                    return result.Distinct(new ResourceComparer()).ToList();
                });
        }

        public OperationResult DeleteResourceEntry(string id)
        {
            return TryInvoke(() => _resourcesRepository.Delete(id));
        }

        public OperationResult<List<Company>> GetCompanyByName(string searchText)
        {
            return TryInvoke(() =>
            {
                if (!String.IsNullOrEmpty(searchText))
                {
                    var lowerSearchText = searchText.ToLower();
                    List<Company> result =new List<Company>();

                    result.AddRange(_companyRepository.SearchAnalyze(i => i.Name, lowerSearchText).ToList());
                    result.AddRange(_companyRepository.Search(i => i.Name.StartsWith(lowerSearchText)
                       || i.Name.StartsWith(lowerSearchText)
                       || i.Name.StartsWith(lowerSearchText)).ToList());

                    return result.Distinct(new CompanyComparer()).ToList();
                }
                else
                {
                    var test = _companyRepository.GetAll().ToList();
                    return test;
                }
            });
        }

        public OperationResult<Company> AddOrUpdateCompany(Company company)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(company.Id))
                    company.Id = Guid.NewGuid().ToString();
                _companyRepository.InsertOrUpdate(company);
                return company;
            });
        }

        public OperationResult DeleteCompanyEntry(string id)
        {
            return TryInvoke(() => _companyRepository.Delete(id));
        }

        public OperationResult<List<Brand>> AddBrand(List<Brand> brandList)
        {
            using (var transaction = new TransactionScope())
            {
                return TryInvoke(() =>
                {
                    foreach (var brand in brandList)
                    {
                        if (string.IsNullOrEmpty(brand.Id))
                            brand.Id = Guid.NewGuid().ToString();
                        _brandRepository.InsertOrUpdate(brand);
                    }
                    transaction.Complete();
                    return brandList;
                });
            }
        }
        
        public OperationResult<string> ShowData(string value)
        {
            return TryInvoke(() =>
            {
                return "You entered value" + value;
            });
        }
    }

    public class ResourceComparer : IEqualityComparer<Resource>
    {
        public bool Equals(Resource x, Resource y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Resource obj)
        {
            return (new Random()).Next(0, int.MaxValue);
        }
    }

    public class CompanyComparer : IEqualityComparer<Company>
    {
        public bool Equals(Company x, Company y)
        {
            return x.Name.Equals(y.Name);
        }
        
        public int GetHashCode(Company obj)
        {
            return (new Random()).Next(0, int.MaxValue);
        }
    }
}