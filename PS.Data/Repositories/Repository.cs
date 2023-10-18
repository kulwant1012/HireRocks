using PS.Data.Entities;
using PS.Data.Indexes;
using PS.Data.Interfaces;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Client.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ServiceStack.Redis;
using Raven.Json.Linq;
using System.IO;
using Raven.Imports.Newtonsoft.Json.Linq;
using Raven.Abstractions.Data;

namespace PS.Data.Repositories
{
    public class Repository<T> : PoolContainer, IRepository<T> where T : class, IEntity
    {
        public void Initialize(string connectionString)
        {
            DocumentStore = new DocumentStore() { ConnectionStringName = connectionString }.Initialize();
            DocumentStore.Conventions.AllowQueriesOnId = true;
        }

        public T GetById(string id)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Load<T>(id); //_cache.Get(id, () => );
            }
        }

        public ICollection<T> GetAll()
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<T>().ToList(); //_cache.Get<ICollection<T>>(typeof(T).Name + "All", () => );
            }

        }

        public ICollection<T> Search(Expression<Func<T, bool>> predicate)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<T>().Where(predicate).ToList();
            }
        }

        public ICollection<T> SearchAnalyze(Expression<Func<T, object>> fieldSelector, string searchText)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<T>().Search(fieldSelector, searchText).ToList();
            }
        }

        public void InsertOrUpdate(T entity)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public T GetEntity<T>(Expression<Func<T, bool>> expression)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return Queryable.Where<T>(session.Query<T>(), expression).Single();
            }
        }

        #region=======EmailVerification
        public void InsertEmailVerificationCode(EmailVerification emailVerification)
        {
            DocumentStore.Initialize();
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(emailVerification, emailVerification.Id);
                session.SaveChanges();
            }
        }

        public EmailVerification GetAllVerificationCodes(string email, string verificationCode)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var data =
                    session.Query<EmailVerification>()
                           .FirstOrDefault(i => i.Email == email && i.VerificationCode == verificationCode);
                return data;
            }
        }
        #endregion


        public void Delete(string id)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var entity = session.Load<T>(id);
                session.Delete(entity);
                session.SaveChanges();
            }
        }

        public void DeleteAll<TEntity>() where TEntity : Entity
        {
            using (var session = DocumentStore.OpenSession())
            {
                var entities = session.Query<TEntity>();
                foreach (var entiry in entities)
                {
                    session.Delete(entiry);
                }
                session.SaveChanges();
            }
        }

        public void InsertMediaFiles(AddMediaFile addMediaFile)
        {
            var data = new MemoryStream(addMediaFile.MediaFile);
            DocumentStore.DatabaseCommands.PutAttachment(addMediaFile.Id, null, data,
                new RavenJObject { { "Content-Type", addMediaFile.ContentType } });
        }

        public void RemoveMediaElement(string id)
        {
            DocumentStore.DatabaseCommands.DeleteAttachment(id, null);
        }

        public string GetDatabaseName()
        {
            return DocumentStore.Url + "/databases/" + ((DocumentStore)DocumentStore).DefaultDatabase + "/static/";
        }
    }
}