using System.Configuration;

namespace Tarabica15.WebAPI.Web.Common
{
    internal class ConnectionStrings
    {
        private static string _connectionString;

        internal static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings[ApiConstants.TarabicaConnectionString].ConnectionString;
                }

                return _connectionString;
            }
        }
    }
}