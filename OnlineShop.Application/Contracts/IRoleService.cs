using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Dtos.RoleDto;
using ResponseFramework;

namespace OnlineShop.Application.Contracts
{
    public interface IRoleService
    {
        Task<IResponse<string>> Delete(string id);
        Task<IResponse<IEnumerable<ServiceSelectRoleDto>>> GetRoles();
        Task<IdentityResult> RegisterRole(ServiceCreateRoleDto createRoleDto);
    }
}