using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PS.Data
{
    public abstract class PoolContainer
    {
        protected static IDocumentStore DocumentStore;
        private IDocumentSession _session;
        private static readonly List<PoolConnection> Connections = new List<PoolConnection>();
        protected static readonly object SynckLock = new object();
        private static readonly Timer Timer = new Timer(CheckConnections, Timer, 0, 1000);

        private static void CheckConnections(object state)
        {
            lock (SynckLock)
            {
                if (Connections.Count > 0 && Connections.Any(i => !i.IsBusy))
                {
                    Connections.RemoveAll(i => !i.IsBusy);
                }
            }
        }

        protected IDocumentSession Session
        {
            get
            {
                lock (SynckLock)
                {
                    //IDocumentSession session;
                    //if (Connections.Count > 0 && Connections.Any(i => !i.IsBusy))
                    //{
                    //    var poolConnection = Connections.First(i => !i.IsBusy);
                    //    poolConnection.IsBusy = true;
                    //    session = poolConnection.Connection;
                    //}
                    //else
                    //{
                    //    session = DocumentStore.OpenSession();
                    //    Connections.Add(new PoolConnection() { Connection = session, IsBusy = true });
                    //}
                    //return session;
                    if (_session == null)
                        _session = DocumentStore.OpenSession();

                    return _session;
                }
            }
        }

    }

    public class PoolConnection
    {
        public IDocumentSession Connection { get; set; }
        public bool IsBusy { get; set; }
    }
}
