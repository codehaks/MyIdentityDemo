using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp.Areas.Admin.Pages.Users
{
    public class RolesModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public IList<RoleViewModel> RoleList { get; set; }

        [BindProperty]
        public string UserId { get; set; }
        [BindProperty]
        public bool IsActive { get; set; }

        public async Task<IActionResult> OnGet(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var userRoles = await _userManager.GetRolesAsync(user);
            RoleList = _roleManager.Roles
                .Select(r => new RoleViewModel
                {
                    Name = r.Name,
                    IsInRole = userRoles.Contains(r.Name)
                })
                .ToList();
            UserId = userId;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.FindByIdAsync(UserId);

            //await _userManager.RemoveFromRolesAsync(user, RoleList.Where(r => r.IsInRole == false).Select(r => r.Name));
            await _userManager
                .AddToRolesAsync(user,
                    RoleList
                    .Where(r => r.IsInRole == true)
                    .Select(r => r.Name));
            //await _userManager.UpdateAsync(user);
            return RedirectToPage("./index");
        }

        public class RoleViewModel
        {
            public string Name { get; set; }
            public bool IsInRole { get; set; }
        }
    }
}