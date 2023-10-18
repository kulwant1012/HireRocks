using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.ServiceModel;
using Newtonsoft.Json;

namespace PS.Azure.Web
{
    public class AzureBlobUploader
    {
        public static string UploadPhoto(byte[] data, string contentType)
        {
            var blockBlobReference = Guid.NewGuid().ToString();
            var blockBlob = GetBlobContainer().GetBlockBlobReference(blockBlobReference);
            using (var stream = new MemoryStream(data))
            {
                blockBlob.Properties.ContentType = contentType;
                blockBlob.UploadFromStream(stream);
                CloudBlockBlob newBlockBlob = GetBlobContainer().GetBlockBlobReference(blockBlobReference);
                return newBlockBlob.Name;
            }
        }

        public static string Post(string url, MultipartFormDataContent multipartFormDataContent)
        {
            string result = string.Empty;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.PostAsync(url, multipartFormDataContent).Result;
                    var stringResult = response.Content.ReadAsStringAsync().Result;
                    var urls = JsonConvert.DeserializeObject<string[]>(stringResult);
                    result = (urls != null) ? urls.FirstOrDefault() : string.Empty;

                }
                catch (Exception e)
                {
                    //Log.Error(e.Message);
                }
                return result;
            }
        }

        private static CloudBlobContainer GetBlobContainer()
        {
            //use this, when contection string will be provided with role
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //       CloudConfigurationManager.GetSetting("blob"));

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["blob"].ConnectionString);


            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container. 
            CloudBlobContainer container = blobClient.GetContainerReference("images");
            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            var permission = new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Container };
            container.SetPermissions(permission);

            return container;
        }

        public static string GetOnlineServerUrl()
        {
            CloudBlobContainer cloudBlobContainer = GetBlobContainer();
            return cloudBlobContainer.Uri.ToString();
        }
    }
}