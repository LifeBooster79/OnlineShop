using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IResponse<ServiceSelectUsersDto>> GetUsers()
        {
            var response=new Response<ServiceSelectUsersDto>();

            var users = await _userManager.Users.ToListAsync();

            ServiceSelectUsersDto usersDto = new ServiceSelectUsersDto();

            usersDto.selectUsers = new List<SelectUserDto>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var roles=await _userManager.GetRolesAsync(user);
                    usersDto.selectUsers.Add(new SelectUserDto()
                    {
                        Id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        phone = user.PhoneNumber,
                        roles=roles
        
                    });

                }
                response.IsSuccessful = true;
                response.Result= usersDto;
            }
            else
            {
                response.Message = "Cant Find Any Users";
                response.IsSuccessful = false;
            }

            return response;
        }
        public async Task<IdentityResult> Update(ServiceUpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(updateUserDto.Id);
            var errors=new List<string>();  
            if (user != null)
            {
                user.UserName = updateUserDto.userName;
                user.Email = updateUserDto.email;
                user.PhoneNumber = updateUserDto.phone;
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
        public async Task<IdentityResult> Delete(ServiceDeleteUserDto deleteDto)
        {
            var user = await _userManager.FindByIdAsync(deleteDto.Id);

            IdentityResult result=new IdentityResult();

            if (user != null) {
                result=await _userManager.DeleteAsync(user);
            }
            
            return result;
        }
        public async Task<IResponse<string>> EditUserRoles(string userId, List<string> roles)
        {
            var response=new Response<string>();
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                response.IsSuccessful = false;
                response.Message = "Cant Find The User";
                return response;
            }
            var currentRoles = await _userManager.GetRolesAsync(user);
            foreach (var item in currentRoles)
            {
                if (!roles.Any(c => c == item))
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, item);
                }
            }
            foreach (var item in roles)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, item);
                if (!isInRole)
                {
                    var addToRoleResult = await _userManager.AddToRoleAsync(user, item);
                }
            }
            response.IsSuccessful = true;
            return response;

        }
    }
}
