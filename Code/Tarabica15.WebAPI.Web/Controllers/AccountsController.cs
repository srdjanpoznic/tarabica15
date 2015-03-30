using System.Net.Http;
using System.Web.Http;
using Tarabica15.WebAPI.Contracts.Interfaces;

namespace Tarabica15.WebAPI.Web.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly IAccountManager _accountManager;

        public AccountsController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public IHttpActionResult Logout()
        {
            // logoff from owin
            var identity = FetchIdentity();
            Request.GetOwinContext().Authentication.SignOut(identity.AuthenticationType);
            
            // logoff user on external service
            _accountManager.Logout(UserDetails.SessionId);

            return Ok(
                new
                {
                    message = "Logout successful."
                }
            );
        }
    }
}
