using System;
using System.Diagnostics;

namespace PS.ActivityVerification.Logging
{
    public class DebugLogger : ILogger
    {
        public void Log(Exception exception, string message)
        {
            Debug.Write(exception.Message + message);
        }
    }
}