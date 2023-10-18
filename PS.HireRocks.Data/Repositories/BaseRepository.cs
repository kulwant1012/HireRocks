using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
    public class BaseRepository
    {
        protected async Task<T> ExecuteAction<T>(Func<T> func)
        {
            return await Task.Factory.StartNew(func);
        }

        protected async Task<Result<T>> TryInvoke<T>(Func<T> func) where T : class
        {
            return await Task.Factory.StartNew(() =>
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
             });
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

        protected async Task<Result> TryInvoke(Action action)
        {
            return await Task.Factory.StartNew(() =>
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
            });
        }

        public void WriteExceptionToDB(string exception)
        {
            using (var entities = new Entities())
            {
                ExceptionLog exceptionLog = new ExceptionLog();
                exceptionLog.Exception = exception;
                exceptionLog.DateTime = DateTime.Now;
                entities.ExceptionLogs.Add(exceptionLog);
                entities.SaveChanges();
            }
        }
    }
}
