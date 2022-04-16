using DevOps.Helper;
using DevOps.Interfaces.Auth;
using DevOps.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Services.AuthManagement
{
    public class JwtToken : IJwt
    {
        private readonly UserManager<BaseUser> _userManager;
        public JwtToken(
            UserManager<BaseUser> userManager
            )
        {
            _userManager = userManager;
        }
        public async Task<JwtSecurityToken> CreateJwtToken(BaseUser user, JWT jwt)
        {


            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email , user.Email),
                new Claim("uid" , user.Id),//Custom claim
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwt.DurationInDays),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;

        }
    }
}