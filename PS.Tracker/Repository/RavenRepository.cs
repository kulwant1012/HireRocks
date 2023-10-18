using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Tracker.Helpers;
using Raven.Client;
using Raven.Client.Document;
using Raven.Json.Linq;

namespace PS.Tracker.Repository
{
    public class RavenRepository
    {
        static IDocumentStore _documentStore = new DocumentStore() { ConnectionStringName = AppConstants.RavenConnectionName }.Initialize();

        public void UploadImage(Image image, string thumbnailImageName, string fullImageName)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    ms.Seek(0, 0);
                    _documentStore.DatabaseCommands.PutAttachment(fullImageName, null, ms, new RavenJObject { { "Content-Type","image/jpeg" } });
                }
                using (var ms = new MemoryStream())
                {
                    image.GetThumbnailImage(200, 180, () => false, IntPtr.Zero).Save(ms, ImageFormat.Jpeg);
                    ms.Seek(0, 0);
                    _documentStore.DatabaseCommands.PutAttachment(thumbnailImageName, null, ms, new RavenJObject { { "Content-Type", "image/jpeg" } });
                }
            }
            catch (Exception)
            {                
                throw;
            }            
        }
    }
}
