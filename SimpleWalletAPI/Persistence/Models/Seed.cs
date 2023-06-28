using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Models
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Admin"},
                new AppRole{Name = "User"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                UserName = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com"
            };

            var user = new AppUser
            {
                UserName = "userOne@gmail.com",
                FirstName = "User",
                LastName = "One",
                Email = "userOne@gmail.com"
,            };


            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRoleAsync(admin, "Admin");

            await userManager.CreateAsync(user, "1111");
            await userManager.AddToRoleAsync(user, "User");
        }
    }
}
