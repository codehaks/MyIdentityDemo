using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Common;
using MyApp.Models;

namespace MyApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IGetClaimsFromUser claims)
            : base(options)
        {
            UserId = claims.UserId;
        }

        private readonly string UserId;

        public override int SaveChanges()
        {
            var userId = UserId;
            return base.SaveChanges();
        }
    }
}
