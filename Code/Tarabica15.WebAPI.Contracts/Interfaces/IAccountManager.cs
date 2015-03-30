using System.Collections.Generic;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Contracts.Interfaces
{
    public interface IAccountManager
    {
        UserDetailsDto LoginUser(string username, string password);
        void Logout(string sessionId);
        List<UserDetailsDto> GetAllUsers(string sessionId);
        bool VerifyToken(string sessionId);
    }
}