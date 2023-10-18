using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;

namespace PS.UploadWeb.Controllers
{
    public class UploadController : ApiController
    {
        private readonly string _imagesDir;
        private readonly string _videoDir;

        private readonly string _imagesServer;
        private readonly string _videoServer;

        public UploadController()
        {
            _imagesDir = ConfigurationManager.AppSettings["imagesVirtualPath"];
            _videoDir = ConfigurationManager.AppSettings["videoVirtualPath"];

            _imagesServer = ConfigurationManager.AppSettings["imagesServer"];
            _videoServer = ConfigurationManager.AppSettings["videoServer"];
        }

        //images/video
        public async Task<string[]> Post([FromUri]string type)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            
            string root = type.ToLower() == "images" ? _imagesDir : _videoDir;
            var provider = new CustomMultipartFormDataStreamProvider(root);

            var baseUrl = type.ToLower() == "images" ? _imagesServer : _videoServer;
            await Request.Content.ReadAsMultipartAsync(provider);
            var urls = new List<string>();

            foreach (MultipartFileData file in provider.FileData)
            {
                var url = baseUrl +  file.Headers.ContentDisposition.FileName;
               urls.Add(url);
            }
            return urls.ToArray();
        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFileStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Replace("\"", string.Empty);
        }
    }
}
