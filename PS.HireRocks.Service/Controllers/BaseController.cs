using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PS.HireRocks.Service.Controllers
{
    public class BaseController : ApiController
    {
        protected Result<T> TryInvoke<T>(Func<T> func) where T : class
        {
            Result<T> operationResult;
            try
            {
                var result = func();
                operationResult = Result<T>.Success(result);
            }
            catch (Exception exception)
            {
                operationResult = Result<T>.Error(exception.Message);
            }
            return operationResult;
        }

        protected Result<T> TryInvoke<T>(Func<Result<T>> func) where T : class
        {
            Result<T> operationResult;
            try
            {
                return func();
            }
            catch (Exception exception)
            {
                operationResult = Result<T>.Error(exception.Message);
            }

            return operationResult;
        }

        protected Result TryInvoke(Func<Result> func)
        {
            try
            {
                return func();
            }
            catch (Exception exception)
            {
                return Result.Error(exception.Message);
            }
        }

        protected Result TryInvoke(Action action)
        {
            Result operationResult;
            try
            {
                action();
                operationResult = Result.Success();
            }
            catch (Exception exception)
            {
                operationResult = Result.Error(exception.Message);
            }

            return operationResult;
        }
    }
}
