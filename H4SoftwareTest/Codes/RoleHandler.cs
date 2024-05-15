using H4SoftwareTest.Data;
using Microsoft.AspNetCore.Identity;

namespace H4SoftwareTest.Codes;

public class RoleHandler
{
    public async Task<bool> CreateUserRolesAsync(string user, string role, IServiceProvider serviceProvider)
    {
        bool isCreated = false;
        try
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var userRoleCheck = await roleManager.RoleExistsAsync(role);
            if (!userRoleCheck)
            {
                var roleObj = new IdentityRole(role);
                await roleManager.CreateAsync(roleObj);
            }

            ApplicationUser identityUser = await userManager.FindByEmailAsync(user);

            // Fjerner brugeren fra alle roller
            var currentRoles = await userManager.GetRolesAsync(identityUser);
            if (currentRoles.Count > 0)
            {
                await userManager.RemoveFromRolesAsync(identityUser, currentRoles);
            }

            // Tilføjer brugeren til ny rolle
            await userManager.AddToRoleAsync(identityUser, role);

            isCreated = true;
        }
        catch(Exception)
        {
            isCreated = false;
        }
        return isCreated;
    }
}
