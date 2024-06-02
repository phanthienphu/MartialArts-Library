using MartialArtsLibrary.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialArtsLibrary.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(MartialArtsLibraryContext context)
        {
            var passWordHasher = new PasswordHasher<AppUser>();
            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name="Admin",
                    NormalizedName="ADMIN",
                    DisplayName="Quản trị hệ thống"
                });
                await context.SaveChangesAsync();
            }
            if(!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName="Han",
                    LastName="Thanh Di",
                    Email="HanThanhDi@gh.com",
                    NormalizedEmail="HANTHANHDI@GH.COM",
                    NormalizedUserName="ADMIN",
                    UserName="admin",
                    IsActive=true,
                    SecurityStamp=Guid.NewGuid().ToString(),
                    //DateCreated = DateTime.Now,
                    LockoutEnabled = false
                };
                user.PasswordHash = passWordHasher.HashPassword(user, "Admin@123456");
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId=rootAdminRoleId,
                    UserId=userId,
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
