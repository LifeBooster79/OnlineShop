using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using ResponseFramework;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineShop.Application.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> Register(ServiceCreateUserDto userDto);
        Task<JwtSecurityToken> Login(ServiceLoginDto userDto);
        Task<IdentityResult> Delete(string id);
    }
}