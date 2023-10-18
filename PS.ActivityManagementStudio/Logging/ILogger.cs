using System;

namespace PS.ActivityManagementStudio.Logging
{
    public interface ILogger
    {
        void Log(Exception exception, string message);
    }
}
