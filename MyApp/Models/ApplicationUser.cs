using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public DateTime? TimeRegister { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Byte[] Image { get; set; }
    }
}
