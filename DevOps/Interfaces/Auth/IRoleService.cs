using DevOps.ViewModels.Accounts;
using System.Threading.Tasks;

namespace DevOps.Interfaces.Auth
{
    public interface IRoleService
    {

        Task<string> AddRoleAsync(RoleDTO model);


    }
}
