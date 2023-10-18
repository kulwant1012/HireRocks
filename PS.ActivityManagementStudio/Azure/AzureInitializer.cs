using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PS.ActivityManagementStudio.Azure
{
    internal static class AzureInitializer
    {
        private readonly static string AttachmentsContainerName;
        private static readonly CloudStorageAccount StorageAccount;

        static AzureInitializer()
        {
            AttachmentsContainerName = ConfigurationManager.AppSettings["AttachmentsContainer"];
            string connectionString = ConfigurationManager.AppSettings["StorageAccount"];
            StorageAccount = CloudStorageAccount.Parse(connectionString);
        }

        public static CloudBlobContainer AttachmentsBlobContainer
        {
            get
            {
                return StorageAccount.CreateCloudBlobClient().GetContainerReference(AttachmentsContainerName);
            }
        }
    }
}
