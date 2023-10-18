using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.WebApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace PS.HireRocks.WebApi.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {  

        protected async Task<T> ExecuteFunction<T>(Func<T> func)
        {
            return await Task.Run(func);
        }

        protected async Task ExecuteFunction(Action act)
        {
            await Task.Run(act);
        }

     
    }
}