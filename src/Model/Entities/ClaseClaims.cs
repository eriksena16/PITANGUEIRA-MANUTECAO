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

            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
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
