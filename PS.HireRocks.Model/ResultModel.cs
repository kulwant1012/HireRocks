using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class Result<T> where T : class
    {
        public bool IsErrorReturned { get; set; }
        public string ErrorMessage { get; set; }
        public T Value { get; set; }

        public Result(T value, bool IsErrorReturned = false, string ErrorMessage = null)
        {
            this.IsErrorReturned = IsErrorReturned;
            this.ErrorMessage = ErrorMessage;
            this.Value = value;
        }
        public Result()
        {

        }
        public Result(bool IsErrorReturned = false, string ErrorMessage = null)
        {
            this.IsErrorReturned = IsErrorReturned;
            this.ErrorMessage = ErrorMessage;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Error(string errorMessage)
        {
            return new Result<T>(true, errorMessage);
        }
    }

    public class Result
    {
        public bool IsErrorReturned { get; set; }
        public string ErrorMessage { get; set; }

        public Result(bool isError = false, string errorMessage = null)
        {
            this.IsErrorReturned = isError;
            this.ErrorMessage = errorMessage;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Error(string msg)
        {
            return new Result(true, msg);
        }
    }
}
