using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Dtos.RoleDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.UserManagementService
{
    
    public class RoleService : IRoleService
    {
        private readonly RoleManager<OnlineShopRole> _roleManager;
        public RoleService(RoleManager<OnlineShopRole> roleManager)
        {
            _roleManager = roleManager;

        }
        public async Task<IdentityResult> RegisterRole(ServiceCreateRoleDto createRoleDto)
        {
            var role = new OnlineShopRole
            {
                Name = createRoleDto.RoleName,
            };
            var result = await _roleManager.CreateAsync(role);

            return result;
        }
        public async Task<IResponse<IEnumerable<ServiceSelectRoleDto>>> GetRoles()
        {
            var response=new Response<IEnumerable<ServiceSelectRoleDto>>();

            var roles=await _roleManager.Roles.ToListAsync();
            var result=new List<ServiceSelectRoleDto>();
            if (roles == null)
            {
                response.IsSuccessful=false;
                response.Message = "There is no role";
                return response;
            }
            foreach (var role in roles)
            {
                result.Add(new ServiceSelectRoleDto()
                {
                    Id = role.Id,
                    roleName = role.Name
                });
            }
            response.IsSuccessful=true;
            response.Result = result;
            return response;
        }
        public async Task<IResponse<string>> Delete(string id)
        {
            var response = new Response<string>();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                response.IsSuccessful = false;
                response.Message = "Cant Find The Role";
            }
            else
            {
                await _roleManager.DeleteAsync(role);
                response.IsSuccessful = true;
            }

            return response;
        }
    }
}
