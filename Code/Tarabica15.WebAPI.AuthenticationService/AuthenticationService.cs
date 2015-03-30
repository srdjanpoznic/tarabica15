using System;
using System.Collections.Generic;
using System.Linq;
using Tarabica15.WebAPI.Contracts.Exceptions;
using Tarabica15.WebAPI.Contracts.Interfaces.Services;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.AuthenticationService
{
    // TODO add logger
    // TODO CallService method
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly List<UserDetailsDto> _usersList = new List<UserDetailsDto>
        {
            new UserDetailsDto
            {
                Id = 1,
                UserName = "ivan.markovic",
                FirstName = "Ivan",
                LastName = "Markovic",
                Language = "ENG",
                SessionId = "123"
            },
            new UserDetailsDto
            {
                Id = 2,
                UserName = "aleksa.petrovic",
                FirstName = "Aleksa",
                LastName = "Petrovic",
                Language = "ENG",
                SessionId = "456"
            },
            new UserDetailsDto
            {
                Id = 3,
                UserName = "marko.ilic",
                FirstName = "Marko",
                LastName = "Ilic",
                Language = "ENG"
            },
        };


        public UserDetailsDto LoginUser(string username, string password)
        {
            var user = _usersList.FirstOrDefault(us => us.UserName == username && password == "admin");

            if (user == null)
                throw new AuthenticationServiceException("User not found.");

            var sessionId = user.SessionId;

            if (!IsSessionLengthOk(sessionId))
                throw new AuthenticationServiceException("Session id length invalid.");

            return user;
        }

        public void LogoutUser(string sessionId)
        {
            // call logout on service
        }

        public List<UserDetailsDto> GetAllUsers(string sessionId)
        {
            return _usersList;
        }

        public bool VerifyToken(string sessionId)
        {
            // verify token on service
            return true;
        }

        private static bool IsSessionLengthOk(string sessionId)
        {
            return !String.IsNullOrEmpty(sessionId);
        }

        // Example of function to call the web service
        //private TResult CallService<TResult>(Func<TResult> function)
        //{
        //    try
        //    {
        //        return function();
        //    }
        //    catch (EndpointNotFoundException ex)
        //    {
        //        throw new AuthenticationServiceException("Authentication service not reachable.", ex);
        //    }
        //    catch (CommunicationException ex)
        //    {
        //        throw new AuthenticationServiceException("Authentication service communication error.", ex);
        //    }
        //    catch (TimeoutException ex)
        //    {
        //        throw new AuthenticationServiceException("Authentication service timeout.", ex);
        //    }
        //}
    }
}
