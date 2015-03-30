using System;
using System.Configuration;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Configuration;

namespace Tarabica15.WebAPI.Web.Common
{
    internal class ApplicationConfiguration : IApplicationConfiguration
    {
        private ILogger _logger;

        public ApplicationConfiguration(ILogger logger)
        {
            _logger = logger;
        }
        
        public int TokenExpireTimeoutInMinutes
        {
            get
            {
                int tokenExpireTimeoutInHours;
                Int32.TryParse(ConfigurationManager.AppSettings[ApiConstants.ConfigurationKeys.TokenExpireTimeoutInMinutes],
                    out tokenExpireTimeoutInHours);

                return tokenExpireTimeoutInHours;
            }
        }

        public string AuthenticationClientId
        {
            get { return ConfigurationManager.AppSettings[ApiConstants.ConfigurationKeys.AuthenticationClientId]; }
        }

        public string AuthenticationClientSecret
        {
            get { return ConfigurationManager.AppSettings[ApiConstants.ConfigurationKeys.AuthenticationClientSecret]; }
        }

        public string WebApiAddress
        {
            get { return ConfigurationManager.AppSettings[ApiConstants.ConfigurationKeys.WebApiAddress]; }
        }

        public int WebApiPort
        {
            get
            {
                int webApiPort;
                int.TryParse(ConfigurationManager.AppSettings[ApiConstants.ConfigurationKeys.WebApiPort], out webApiPort);

                return webApiPort;
            }
        }
    }
}