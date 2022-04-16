using DevOps.Enum;
using DevOps.Models;
using DevOps.ViewModels.Accounts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DevOps.Interfaces.Auth
{
    public interface IRegisterService
    {
        Task<AuthModel> RegisterAsync(RegisterDto model);

    }
}
