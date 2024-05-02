using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Dtos.UserDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineShop.Application.Contracts
{
    public interface IAccountService
    {
        Task<JwtSecurityToken> Login(ServiceLoginDto userDto);
        Task<IdentityResult> Register(ServiceCreateUserDto userDto);
    }
}