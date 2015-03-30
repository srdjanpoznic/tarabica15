
namespace Tarabica15.WebAPI.Web.Common
{
    class ApiConstants
    {
        public const string TarabicaConnectionString = "Tarabica15Context";

        internal class AuthenticationKeys
        {
            public const string LineId = "lineId";
            public const string Username = "userName";
            public const string ClientId = "as:client_id";
            public const string LastLogin = "LastLogin";
        }

        internal class ConfigurationKeys
        {
            public const string WebApiAddress = "WebApiAddress";
            public const string WebApiPort = "WebApiPort";
            public const string TokenExpireTimeoutInMinutes = "TokenExpireTimeoutInMinutes";
            public const string AuthenticationClientId = "AuthenticationClientId";
            public const string AuthenticationClientSecret = "AuthenticationClientSecret";
        }
    }
}