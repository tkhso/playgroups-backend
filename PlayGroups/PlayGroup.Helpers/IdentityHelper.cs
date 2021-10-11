using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Playgroup.Helpers
{
    public static class IdentityHelper
    {
        public static string GetClaim(this ClaimsIdentity identity, string key)
        {
            var claim = identity.Claims.FirstOrDefault(x => x.Type == key);
            if (claim == null)
                return null;

            return claim.Value;
        }

        public static int? GetUserID(this ClaimsIdentity identity)
        {
            if (identity == null)
                return null;

            if (identity.GetClaim(ClaimTypes.Sid) != null)
            {
                int res;
                return Int32.TryParse(identity.GetClaim(ClaimTypes.Sid), out res) ? res : (int?)null;
            }
            else
            {
                int res;
                return Int32.TryParse(identity.GetClaim(ClaimTypes.NameIdentifier), out res) ? res : (int?)null;
            }
        }
    }

    public class AuthHelper<TUser> where TUser : IdentityUser<int>
    {
        public readonly UserManager<TUser> UserManager;
        public readonly SignInManager<TUser> SignInManager;

        public AuthHelper(UserManager<TUser> userManager, SignInManager<TUser> signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }
    }
}
