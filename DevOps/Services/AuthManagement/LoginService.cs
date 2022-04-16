using DevOps.Helper;
using DevOps.Interfaces.Auth;
using DevOps.Models;
using DevOps.ViewModels.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps.Services.AuthManagement
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly JWT jwt;
        private readonly IJwt jwtToken;

        public LoginService(UserManager<BaseUser> userManager, IOptions<JWT> jwt, IJwt jwtToken)
        {
            this.userManager = userManager;
            this.jwt = jwt.Value;
            this.jwtToken = jwtToken;
        }

        public async Task<AuthModel> GetTokenAsync(LoginDto model)
        {
            var authModel = new AuthModel();
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Messages = "Email or password is incorrect";
                return authModel;
            }

            var jwtSecurityToken = await jwtToken.CreateJwtToken(user, jwt);
            var roleList = await userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Username = user.UserName;
            authModel.Email = user.Email;
            authModel.Roles = roleList.ToList();
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;

            return authModel;
        }
    }
}
