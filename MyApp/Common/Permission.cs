using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public enum Permission:short
    {
        None=0,

        [Display(GroupName ="Admin",Name ="Read Admin Dashboard")]
        ReadAdminDashboard=1,

        [Display(GroupName = "Admin", Name = "Read Admin Users")]
        ReadAdminUsers =2
    }
}
