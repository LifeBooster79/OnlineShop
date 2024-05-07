using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using ResponseFramework;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineShop.Application.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> Update(ServiceUpdateUserDto updateUserDto);
        Task<IResponse<ServiceSelectUsersDto>> GetUsers();
        Task<IdentityResult> Delete(ServiceDeleteUserDto deleteDto);
        Task<IResponse<string>> EditUserRoles(string userId, List<string> roles);
    }
}