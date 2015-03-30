namespace Tarabica15.WebAPI.Contracts.Configuration
{
    public interface IApplicationConfiguration
    {
        int TokenExpireTimeoutInMinutes { get; }
        string AuthenticationClientId { get; }
        string AuthenticationClientSecret { get; }
        string WebApiAddress { get; }
        int WebApiPort { get; }
    }
}