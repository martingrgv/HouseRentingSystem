using HouseRentingSystem.Infrastructure.Data.Models;

namespace Microsoft.AspNetCore.Identity
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using (var scopedServices = app.ApplicationServices.CreateScope())
            {
                var services = scopedServices.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdminUser.AdminRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdminUser.AdminRoleName };
                    await roleManager.CreateAsync(role);

                    var admin = await userManager.FindByNameAsync(AdminUser.AdminEmail);
                    await userManager.AddToRoleAsync(admin, role.Name);
                })
                .GetAwaiter()
                .GetResult();

                return app;
            }
        }
    }
}
