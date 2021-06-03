using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Infrastructure.IdentityExtesions
{
    public static class IdentityExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(c => c.Type.EndsWith("emailaddress"))?.Value;
        }
    }
}
