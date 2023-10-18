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
using System;
namespace PS.Azure.Web
{
    public partial class PSService : IMediaElementService
    {
        public OperationResult<AddMediaFile> UploadMedia(AddMediaFile addMediaFile)
        {
            return TryInvoke(() =>
            {
                try
                {
                    _resourceRepository.InsertMediaFiles(addMediaFile);
                    addMediaFile.MediaFile = null;
                }
                catch (Exception ex)
                {
                    addMediaFile.MediaFile = null;
                    throw;
                }

                return addMediaFile;
            });
        }
        public OperationResult RemoveMedia(string id)
        {
            return TryInvoke(() =>
            {
                try
                {
                    _resourceRepository.RemoveMediaElement(id);

                }
                catch (Exception ex)
                {

                }
            });
        }
    }
}
