using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.Owin;
using Tarabica15.WebAPI.Contracts.Models;
using Tarabica15.WebAPI.Web.Helpers;

namespace Tarabica15.WebAPI.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        #region [Members]
        
        #endregion

        #region [CTOR]

        #endregion

        #region [Methods]

        public IOwinContext OwinContext
        {
            get
            {
                return Request.GetOwinContext();
            }
        }

        public UserDetailsDto UserDetails
        {
            get
            {
                var userDetails = ClaimsUtility.GetUserDetails();

                if (userDetails == null)
                {
                    throw new AuthenticationException("User is not logged in.");
                }

                return userDetails;
            }
        }

        public ClaimsPrincipal FetchPrincipal()
        {
            return ClaimsPrincipal.Current;
        }

        public ClaimsIdentity FetchIdentity()
        {
            return ClaimsPrincipal.Current.Identity as ClaimsIdentity;
        }

        #endregion
    }
}
