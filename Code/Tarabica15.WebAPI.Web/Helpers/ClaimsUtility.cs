using System.Globalization;
using System.Security.Claims;
using Tarabica15.WebAPI.Contracts.Models;
using Tarabica15.WebAPI.Web.Common;

namespace Tarabica15.WebAPI.Web.Helpers
{
    public class ClaimsUtility
    {
        /// <summary>
        /// Sets the claims identity for the user
        /// </summary>
        /// <param name="userDetails">The user details.</param>
        /// <param name="authenticationType">Type of the authentication.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public static ClaimsIdentity CreateClaimsIdentity(UserDetailsDto userDetails, string clientId,
            string authenticationType)
        {
            var claimIdentity = new ClaimsIdentity(authenticationType);

            claimIdentity.AddClaim(new Claim(ClaimTypes.Sid, userDetails.Id.ToString(CultureInfo.InvariantCulture)));

            if (!string.IsNullOrEmpty(clientId))
                claimIdentity.AddClaim(new Claim(ApiConstants.AuthenticationKeys.ClientId, clientId));

            if (!string.IsNullOrWhiteSpace(userDetails.UserName))
                claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userDetails.UserName));

            if (!string.IsNullOrEmpty(userDetails.FirstName))
                claimIdentity.AddClaim(new Claim(ClaimTypes.Name, userDetails.FirstName));

            if (!string.IsNullOrEmpty(userDetails.LastName))
                claimIdentity.AddClaim(new Claim(ClaimTypes.Surname, userDetails.LastName));

            return claimIdentity;
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <returns></returns>
        public static UserDetailsDto GetUserDetails()
        {
            UserDetailsDto userDetails = null;

            if (ClaimsPrincipal.Current != null &&
                ClaimsPrincipal.Current.Identity != null &&
                ClaimsPrincipal.Current.Identity.IsAuthenticated)
            {
                var principal = ClaimsPrincipal.Current;
                int userId;
                long lastLoginBinary;

                userDetails = new UserDetailsDto
                {
                    Id = int.TryParse(principal.FindFirst(ClaimTypes.Sid).Value, out userId)
                        ? userId
                        : default(int),
                    UserName = principal.FindFirst(ClaimTypes.NameIdentifier).Value,
                    FirstName = principal.FindFirst(ClaimTypes.Name).Value,
                    LastName = principal.FindFirst(ClaimTypes.Surname).Value,
                    SessionId = principal.FindFirst(ClaimTypes.UserData).Value
                };
            }

            return userDetails;
        }
    }
}