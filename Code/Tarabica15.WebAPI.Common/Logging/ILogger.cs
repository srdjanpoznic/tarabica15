using System;

namespace Tarabica15.WebAPI.Common.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void InfoFormat(string format, params object[] args);
        void Warn(string message);
        void WarnFormat(string format, params object[] args);
        void Debug(string message);
        void DebugIf(bool condition, string message);
        void DebugFormat(string format, params object[] args);
        void Debug(string message, Exception ex);
        void Error(string message);
        void Error(Exception ex);
        void ErrorIf(bool condition, string message);
        void ErrorFormat(string format, params object[] args);
        void Error(string message, Exception ex);
        void Fatal(string message);
        void Fatal(string message, Exception ex);
    }
}