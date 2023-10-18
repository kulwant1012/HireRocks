using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.IO;
using Raven.Client.Embedded;
using PS.ActivityVerification.PSServiceReference;
using Raven.Json.Linq;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Abstractions.Commands;

namespace PS.ActivityVerification
{
    public class OfflineDataBaseRepository<T> where T : class
    {
        EmbeddableDocumentStore DocumentStore;
        public OfflineDataBaseRepository()
        {
            DocumentStore = new EmbeddableDocumentStore() { DataDirectory = "Data" };
            DocumentStore.Initialize();
            DocumentStore.Conventions.AllowQueriesOnId = true;
        }

        public async Task<ICollection<T>> GetAllAsync<T>()
        {
            using (var session = DocumentStore.OpenAsyncSession())
            {
                return await session.Query<T>().ToListAsync();
            }
        }

        public async void InsertOrUpdateAsync(T entity)
        {
            using (var session = DocumentStore.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }
        }

        public void Delete(string id)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Advanced.Defer(new DeleteCommandData { Key = id });
                session.SaveChanges();
            }
        }

        public Raven.Abstractions.Data.Attachment GetAttachment(string attachmentId)
        {
            return DocumentStore.DatabaseCommands.GetAttachment(attachmentId);
        }

        public void InsertAttachment(AddMediaFile addMediaFile)
        {
            var data = new MemoryStream(addMediaFile.MediaFile);
            DocumentStore.DatabaseCommands.PutAttachment(addMediaFile.Id, new Etag(), data,
                new RavenJObject { { "Content-Type", addMediaFile.ContentType } });
        }

        public void DeleteAttachment(string id)
        {
            DocumentStore.DatabaseCommands.DeleteAttachment(id, null);
        }
    }
}
