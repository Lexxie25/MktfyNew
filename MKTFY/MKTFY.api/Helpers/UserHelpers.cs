using System.Security.Claims;

namespace MKTFY.api.Helpers
{
    /// <summary>
    /// helper method for changing token from auth0 to id 
    /// </summary>
    public static class UserHelpers
    {
        /// <summary>
        /// helper method for changing token from auth0 to id 
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetId(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier) ?? principal.FindFirst(c => c.Type == "sub");
            if (userIdClaim != null && !string.IsNullOrEmpty(userIdClaim.Value))
                return userIdClaim.Value;

            return null;
        }
    }
}
