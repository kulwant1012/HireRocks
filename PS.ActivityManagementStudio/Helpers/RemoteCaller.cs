using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Threading;

namespace PS.ActivityManagementStudio.Helpers
{
    /// <summary>
    /// This class provides central mechanism for asyncronous remote calls
    /// </summary>
    public static class RemoteCaller
    {
        public static void Call<T>(Func<T> func)
        {
            Call(func, null);
        }

        /// <summary>
        /// Calls specified function synchronously and notifies the client by calling client action delegate.
        /// This method handles SquawkerServerException and other possible exceptions and passes them for the client
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="clientAction"></param>
        public static void CallSync<T>(Func<T> func, Action<T, Exception> clientAction = null)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            var result = default(T);
            Exception exception = null;

            try
            {
                // Intialize the result 
                result = func.Invoke();

                if (!(result is ValueType) && Equals(result, default(T)))
                {
                    // Just create an exception but not throw it
                    exception = new ApplicationException("Server returned null");
                }

            }
            catch (Exception ex)
            {
                // We can't throw exception again because it would be unhandled then
                exception = ex;
            }

            if (clientAction != null)
                clientAction(result, exception);
        }

        /// <summary>
        /// Calls specified function asynchronously and notifies the client by calling client action delegate.
        /// This method handles SquawkerServerException and other possible exceptions and passes them for the client
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="func">This delegate represents client remote call with the specified signature. 
        /// This call will be executed asynchronously and on completion the client Action delegate will be executed</param>
        /// <param name="clientAction">This action is being executed after the remote call is completed. Remote call result and exception is being passed
        /// to this delegate in interest to notify aboput results and possible exceptions. The client code should handle exceptions correspondingly.</param>
        /// <returns></returns>
        public static void Call<T>(Func<T> func, Action<T, Exception> clientAction)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Call asynchrnously
            func.BeginInvoke(EndCallback<T>, clientAction);
        }


        // This is call ed when the asynchronous operation (func) id completed
        private static void EndCallback<T>(IAsyncResult ar)
        {
            var asyncResult = (AsyncResult)ar;
            Debug.Assert(asyncResult != null);

            // Retrieve caller delegate.
            var caller = (Func<T>)asyncResult.AsyncDelegate;
            Debug.Assert(caller != null);

            var result = default(T);
            Exception exception = null;
            try
            {
                // Intialize the result 
                result = caller.EndInvoke(ar);

                if (!(result is ValueType) && Equals(result, default(T)))
                {
                    // Just create an exception but not throw it
                    exception = new ApplicationException("Remote Caller: calling delegate returned null.");
                }

            }
            catch (Exception ex)
            {
                exception = ex;
            }

            var act = (Action<T, Exception>)ar.AsyncState;

            if (act == null)
                return;

            //Debug.Assert(!Equals(act, default(Action<T, Exception>)));


            if (DispatcherHelper.UIDispatcher != null)
                // UI context. Call UI side delegate from this thread using dispatcher
                DispatcherHelper.UIDispatcher.BeginInvoke(act, result, exception);
            else
                act(result, exception);

        }
    }
}
