using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Pitangueira.Model.Entities
{
    public static class ClaseClaims
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
            {
                throw new ArgumentNullException(nameof(claimsPrincipal));
            }
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
            {
                throw new ArgumentNullException(nameof(claimsPrincipal));
            }
            return claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
        }

    }
}
