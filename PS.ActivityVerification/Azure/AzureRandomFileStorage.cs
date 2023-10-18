using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PS.ActivityVerification.Azure
{
    public class AzureRandomFileStorage
    {
        protected readonly CloudBlobContainer Container;
        protected readonly string _basePath;
        private readonly string _containerPath;

        public AzureRandomFileStorage(CloudBlobContainer container, string basePath)
        {
            Container = container;
            Container.CreateIfNotExists();

            //setted public access for all blobs
            Container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });
            _containerPath = Container.Uri.AbsoluteUri;
            _basePath = basePath.TrimEnd('/') + "/";
        }

        public async Task<string> WriteAsync(Stream data, IDictionary<string, string> metadata = null)
        {
            string blobName = _basePath + Guid.NewGuid().ToString("N");
            CloudBlockBlob blob = Container.GetBlockBlobReference(blobName);
            if (metadata != null)
            {
                foreach (var meta in metadata)
                    blob.Metadata[meta.Key] = meta.Value;
            }
            data.Position = 0;

            await blob.UploadFromStreamAsync(data);
            return blob.Uri.AbsoluteUri;
        }


        public async Task ReadAsync(string uri, Stream data)
        {
            if (!uri.StartsWith(_containerPath))
                throw new ArgumentException(
                    String.Format("Uri does not match container url. Container: {0} Blob: {1}", _containerPath, uri),
                    "uri");
            string blobname = uri.Substring(_containerPath.Length + 1);
            CloudBlockBlob blob = Container.GetBlockBlobReference(blobname);
            await blob.DownloadToStreamAsync(data);
        }
    }
}