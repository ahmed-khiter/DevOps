using DevOps.Helper;
using DevOps.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DevOps.Interfaces.Auth
{
    public interface IJwt
    {
        Task<JwtSecurityToken> CreateJwtToken(BaseUser user, JWT jwt);
    }
}
