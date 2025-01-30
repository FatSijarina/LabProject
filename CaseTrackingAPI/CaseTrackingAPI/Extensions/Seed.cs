using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CaseTrackingAPI.Extensions
{
    public class Seed
    {
        public static async Task SeedData(CaseDbContext context,
            UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user1 = new User
                {
                    UserName = "tim",
                    Email = "tim@test.com"
                };

                await userManager.CreateAsync(user1, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user1, "Prokuror");

                var user2 = new User
                {
                    UserName = "john",
                    Email = "john@test.com"
                };

                await userManager.CreateAsync(user2, "Pa$$w0rd");
                await userManager.AddToRolesAsync(user2, new[] { "Prokuror", "Detektiv" });
            }
        }
    }
}
