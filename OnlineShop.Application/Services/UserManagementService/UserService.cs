using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineShop.Application.Services.UserManagementService
{
    public class UserService :IUserService
    {

        private readonly UserManager<OnlineShopUser> _userManager;

        private readonly RoleManager<OnlineShopRole> _roleManager;

        private readonly IConfiguration _configuration;

        public UserService(UserManager<OnlineShopUser> userManager, RoleManager<OnlineShopRole> roleManager,IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> Update(ServiceUpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(updateUserDto.Id);
            var errors=new List<string>();  
            if (user != null)
            {
                user.UserName = updateUserDto.UserName;
                user.Email = updateUserDto.Email;
                user.PhoneNumber = updateUserDto.PhoneNumber;
                return await _userManager.UpdateAsync(user);
            }
            else
            {
               return  IdentityResult.Failed(
               new IdentityError[] {
                  new IdentityError{
                     Code = "0001",
                     Description = "Cant Find The User"
                  }
               }
                );
            }


            
        }
        public async Task<IdentityResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            IdentityResult result=new IdentityResult();

            if (user != null) {
                result=await _userManager.DeleteAsync(user);
            }
            
            return result;
        }
    }
}
