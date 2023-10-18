using System;

namespace PS.ActivityVerification.Logging
{
    public interface ILogger
    {
        void Log(Exception exception, string message);
    }
}