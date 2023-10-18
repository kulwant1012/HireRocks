using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Azure.Web
{
    [DataContract]
    public class OperationResult<T>
    {
        [DataMember]
        public bool IsErrorReturned {get; set;}
        [DataMember]
        public string ErrorMessage {get; set;}
        [DataMember]
        public T Value { get; private set; }

        public OperationResult()
        {

        }

        public OperationResult(T value, bool isError = false, string errorMessage = null)
        {
            this.Value = value;
            this.IsErrorReturned = isError;
            this.ErrorMessage = errorMessage;
        }

        public OperationResult(bool isError = false, string errorMessage = null)
        {            
            this.IsErrorReturned = isError;
            this.ErrorMessage = errorMessage;
        }

        public static OperationResult<T> Success(T value)
        {
            return new OperationResult<T>(value);
        }

        public static OperationResult<T> Error(string msg)
        {
            return new OperationResult<T>(true, msg);
        }
    }

    [DataContract]
    public class OperationResult
    {
        [DataMember]
        public bool IsErrorReturned { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }

        public OperationResult()
        {

        }

        public OperationResult(bool isError = false, string errorMessage = null)
        {
            this.IsErrorReturned = isError;
            this.ErrorMessage = errorMessage;
        }

        public static OperationResult Success()
        {
            return new OperationResult();
        }

        public static OperationResult Error(string msg)
        {
            return new OperationResult(true, msg);
        }
    }
}
