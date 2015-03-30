using System;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Tarabica15.WebAPI.Common.Logging
{
    /// <summary>
    /// Implementation of custom logger (NLog, log4Net, etc.)
    /// </summary>
    public class Log4netLogger : ILogger
    {
        private static volatile object _lock = new object();
        private readonly ILog _logger;

        static Log4netLogger()
        {
        }

        public Log4netLogger()
        {
            if (_logger != null)
                return;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            XmlConfigurator.Configure();
        }

        public void Log(string info)
        {
            lock (_lock)
                _logger.Info(info);
        }

        public void Log(Exception ex)
        {
            lock (_lock)
                _logger.Error(ex);
        }

        public void Info(string message)
        {
            lock (_lock)
                _logger.Error(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            lock (_lock)
                _logger.InfoFormat(format, args);
        }

        public void Warn(string message)
        {
            lock (_lock)
                _logger.Warn(message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            lock (_lock)
                _logger.WarnFormat(format, args);
        }

        public void Debug(string message)
        {
            lock (_lock)
                _logger.Debug(message);
        }

        public void DebugIf(bool condition, string message)
        {
            if (!condition)
                return;
            Debug(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            lock (_lock)
                _logger.DebugFormat(format, args);
        }

        public void Debug(string message, Exception ex)
        {
            lock (_lock)
                _logger.Debug(message, ex);
        }

        public void Error(string message)
        {
            lock (_lock)
                _logger.Error(message);
        }

        public void ErrorIf(bool condition, string message)
        {
            if (!condition)
                return;
            Error(message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            lock (_lock)
                _logger.ErrorFormat(format, args);
        }

        public void Error(string message, Exception ex)
        {
            lock (_lock)
                _logger.Error(message, ex);
        }

        public void Error(Exception ex)
        {
            lock (_lock)
                _logger.Error(ex);
        }

        public void Fatal(string message)
        {
            lock (_lock)
                _logger.Fatal(message);
        }

        public void Fatal(string message, Exception ex)
        {
            lock (_lock)
                _logger.Fatal(message, ex);
        }
    }
}