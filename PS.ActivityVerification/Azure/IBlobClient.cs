using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PS.ActivityVerification.Azure
{
    public interface IBlobClient
    {
        Task<string> WriteAsync<T>(T value) where T : class;
        Task<T> ReadAsync<T>(string url) where T : class;
        Task DeleteAsync(string url);
        IEnumerable<string> GetAllUrls();

        Task<string> WriteAsync(Stream data, IDictionary<string, string> metadata = null);
    }
}