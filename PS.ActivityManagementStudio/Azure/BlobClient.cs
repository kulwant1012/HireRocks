using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PS.ActivityManagementStudio.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace PS.ActivityManagementStudio.Azure
{
    public class BlobClient : AzureRandomFileStorage, IBlobClient
    {
        private readonly ILogger _logger;

        public BlobClient(CloudBlobContainer container, string basePath, ILogger logger)
            : base(container, basePath)
        {
            _logger = logger;
        }

        public async Task<string> WriteAsync<T>(T value) where T : class
        {
            var json = JsonConvert.SerializeObject(value);
            using (var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return await base.WriteAsync(dataStream);
            }
        }

        public async Task<string> WriteFileAsync(string fileName, FileMode fileMode)
        {
            var blobName = _basePath + Path.GetFileName(fileName);
            var blob = Container.GetBlockBlobReference(blobName);

            await blob.UploadFromFileAsync(fileName, fileMode);
            return blob.Uri.AbsoluteUri;
        }
      
        public async Task<T> ReadAsync<T>(string url) where T : class
        {
            using (var stream = new MemoryStream())
            {
                T result = default(T);
                try
                {
                    await ReadAsync(url, stream);
                }
                catch (StorageException exception)
                {
                    _logger.Log(exception, "BlobClient.ReadAsync");
                }

                if (stream.Length > 0)
                {
                    var json = Encoding.UTF8.GetString(stream.ToArray());
                    result = JsonConvert.DeserializeObject<T>(json);
                }

                return result;
            }
        }

        public async Task DeleteAsync(string url)
        {
            try
            {

                var blobBlockReference = await Container.GetBlobReferenceFromServerAsync(url);
                await blobBlockReference.DeleteIfExistsAsync();
            }
            catch (Exception e)
            {
            }
        }


        public IEnumerable<string> GetAllUrls()
        {
            return GetUrlsFromBlobs(Container.ListBlobs(null, false));
        }

        private IEnumerable<string> GetUrlsFromBlobs(IEnumerable<IListBlobItem> blobs)
        {
            var uris = new List<string>();
            foreach (var listBlobItem in blobs)
            {
                if (listBlobItem is CloudBlockBlob)
                {
                    var blob = (CloudBlockBlob)listBlobItem;

                    uris.Add(blob.Uri.AbsoluteUri);

                }
                else if (listBlobItem is CloudBlobDirectory)
                {
                    var directory = (CloudBlobDirectory)listBlobItem;

                    uris.AddRange(GetUrlsFromBlobs(directory.ListBlobs(false)));
                }
            }

            return uris;
        }
    }
}
