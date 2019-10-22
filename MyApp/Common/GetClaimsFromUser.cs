using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public class GetClaimsFromUser : IGetClaimsFromUser
    {
        public string UserId { get; private set; }

        public GetClaimsFromUser(IHttpContextAccessor accessor)
        {
            var user = accessor.HttpContext?.User;
            var userName = user.Identity.Name;

            UserId = accessor.HttpContext?.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
