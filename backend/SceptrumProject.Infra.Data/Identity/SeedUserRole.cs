// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using Microsoft.AspNetCore.Identity;
using SceptrumProject.Domain.SecurityAccount;
using System;

namespace SceptrumProject.Infra.Data.Identity
{
    public class SeedUserRole : ISeedUserRole
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRole(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "usuario@mail.com",
                    Email = "usuario@mail.com",
                    NormalizedUserName = "USUARIO@MAIL.COM",
                    NormalizedEmail = "USUARIO@MAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "MyPassword#123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@mail.com").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "admin@mail.com",
                    Email = "admin@mail.com",
                    NormalizedUserName = "ADMIN@MAIL.COM",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "MyPassword#123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

    }
}
