using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> FindAllClaims(this ClaimsPrincipal claimprincipal,string claimType)
        {
            return claimprincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        }
        public static List<string> FindClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindAllClaims(ClaimTypes.Role);
        }
        public static string FindNameIdentifierClaim(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindAllClaims(ClaimTypes.NameIdentifier)[0];
        }
    }
}
