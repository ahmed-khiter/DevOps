using DevOps.ViewModels.Accounts;
using System.Threading.Tasks;

namespace DevOps.Interfaces.Auth
{
    public interface ILoginService
    {
        Task<AuthModel> GetTokenAsync(LoginDto model);
    }
}
