﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public class MyClaimsPrincipalFactory : 
        UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyClaimsPrincipalFactory(
           UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           IOptions<IdentityOptions> optionsAccessor)
           : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claims = await base.GenerateClaimsAsync(user);

            claims.AddClaim(new Claim("FirstName", user.FirstName));
            claims.AddClaim(new Claim("LastName", user.LastName));

            return claims;
        }
    }
}
