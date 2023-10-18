using System;
using System.Diagnostics;

namespace PS.ActivityManagementStudio.Logging
{
    public class DebugLogger : ILogger
    {
        public void Log(Exception exception, string message)
        {
            Debug.Write(exception.Message + message);
        }
    }
}
