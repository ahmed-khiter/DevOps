using DevOps.Constants;
using DevOps.Enum;
using DevOps.Helper;
using DevOps.Interfaces.Auth;
using DevOps.Models;
using DevOps.ViewModels.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DevOps.Services.AuthManagement
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly JWT jwt;
        private readonly IJwt jwtToken;



        public RegisterService(UserManager<BaseUser> userManager,
            IOptions<JWT> jwt, IJwt jwtToken)
        {
            this.userManager = userManager;
            this.jwt = jwt.Value;//Read from appstting.json
            this.jwtToken = jwtToken;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDto model)
        {
            if (await userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Messages = "Email is already registered" };

            if (await userManager.FindByNameAsync(model.NickName) is not null)
                return new AuthModel { Messages = "Username is already registered" };

            var user = new BaseUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = $"{model.FirstName} {model.LastName}",
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                AccountType = model.BaseUserType
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{ error.Description}, ";
                }
                return new AuthModel { Messages = errors };
            }


            //Generate Token to user
            var jwtSecurityToken = await jwtToken.CreateJwtToken(user, jwt);

            return new AuthModel
            {
                Email = user.Email,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Username = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpiresOn = jwtSecurityToken.ValidTo
            };
        }

    }
}
