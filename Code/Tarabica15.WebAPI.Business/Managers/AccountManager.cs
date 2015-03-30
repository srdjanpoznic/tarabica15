using System.Collections.Generic;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Exceptions;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Interfaces.Services;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Business.Managers
{
    public class AccountManager : BaseManager, IAccountManager
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountManager(IAuthenticationService authenticationService, ILogger logger)
            : base(logger)
        {
            _authenticationService = authenticationService;
        }
        
        public UserDetailsDto LoginUser(string username, string password)
        {
            try
            {
                return _authenticationService.LoginUser(username, password);
            }
            catch (AuthenticationServiceException ex)
            {
                // message contains friendly message
                throw new BusinessException(ex.Message, ex);
            }
        }

        public void Logout(string sessionId)
        {
            _authenticationService.LogoutUser(sessionId);
        }

        public bool VerifyToken(string sessionId)
        {
            return _authenticationService.VerifyToken(sessionId);
        }

        //TODO SHOW Exception handling
        public List<UserDetailsDto> GetAllUsers(string sessionId)
        {
            // example with logger and exception handling
            Logger.DebugFormat("GetAllUsers called for session [{0}]", sessionId);

            try
            {
                return _authenticationService.GetAllUsers(sessionId);
            }
            catch (AuthenticationServiceException ex)
            {
                // message contains friendly message
                throw new BusinessException(ex.Message, ex);
            }
        }
        
        //This method is never been called, but I think the compiler will remove all
        //"unnecessary" assemblies and without using the EntityFramework.SqlServer
        //stuff the test fails.
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}