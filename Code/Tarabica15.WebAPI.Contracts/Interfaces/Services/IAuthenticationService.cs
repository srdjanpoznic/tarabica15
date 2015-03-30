using System.Collections.Generic;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Contracts.Interfaces.Services
{
    public interface IAuthenticationService
    {
        UserDetailsDto LoginUser(string username, string password);
        void LogoutUser(string sessionId);
        List<UserDetailsDto> GetAllUsers(string sessionId);
        bool VerifyToken(string sessionId);
    }
}
