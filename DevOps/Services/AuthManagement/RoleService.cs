using DevOps.Interfaces.Auth;
using DevOps.Models;
using DevOps.ViewModels.Accounts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DevOps.Services.AuthManagement
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleService(UserManager<BaseUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<string> AddRoleAsync(RoleDTO model)
        {
            var user = await userManager.FindByIdAsync(model.BaseUserId);

            if (user is null || !await roleManager.RoleExistsAsync(model.RoleName))
                return "Invalid username or role";

            if (await userManager.IsInRoleAsync(user, model.RoleName))
                return "User already assigned to this role";

            var result = await userManager.AddToRoleAsync(user, model.RoleName);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

    }
}
