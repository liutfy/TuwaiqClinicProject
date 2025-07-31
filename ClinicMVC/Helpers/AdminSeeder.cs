using Microsoft.AspNetCore.Identity;
using ClinicMVC.Models;

namespace ClinicMVC.Helpers
{
    public class AdminSeeder
    {
        public static async Task CreateAdminUser(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUsers>>();

            var adminEmail = "admin@clinic.com";
            var adminPassword = "Admin@123";

            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new AppUsers
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }

                result = await userManager.AddToRoleAsync(admin, AppRoles.Admin.ToString());
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to add admin user to Admin role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
