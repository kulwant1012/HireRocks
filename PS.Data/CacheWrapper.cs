using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using PS.Data.Interfaces;

namespace PS.Data
{
    public class CacheWrapper
    {
        //private readonly IRedisClientsManager _redisClientsManager = new BasicRedisClientManager();
        private TimeSpan _expiresAt;
        private IRedisClient _redis;

        public void Initialize(TimeSpan expiresAt)
        {
            _expiresAt = expiresAt;
            try
            {
                //_redis = _redisClientsManager.GetClient();
            }
            catch (Exception)
            {
                _redis = null;
            }

        }

        public T Get<T>(string key, Func<T> repositoryFunc) where T : class
        {
            return  repositoryFunc.Invoke();
            //T cacheItem = null;
            //if (_redis != null)
            //{
            //    try
            //    {
            //        cacheItem = _redis.Get<T>(key);
            //    }
            //    catch (Exception)
            //    {
            //    }

            //    if (cacheItem == null)
            //    {
            //        cacheItem = repositoryFunc.Invoke();
            //        try
            //        {
            //            bool replease = _redis.Replace(key, cacheItem, _expiresAt);
            //            if (!replease)
            //                _redis.Add(key, cacheItem, _expiresAt);
            //        }
            //        catch (Exception)
            //        {
            //        }


            //    }
            //}
            //else
            //{
            //    cacheItem = repositoryFunc.Invoke();
            //}
            //return cacheItem;
           
        }
    }
}
