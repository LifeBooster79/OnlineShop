using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Application.Services.UserManagementService;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPut]
        public async Task<IActionResult> Update(ServiceUpdateUserDto model)
        {
            if(model!=null)
            {
                var result = await _userService.Update(model);
                if (result.Succeeded)
                {
                    return Ok(result); 
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result= await _userService.GetUsers();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(ServiceDeleteUserDto model)
        {
            var result=await _userService.Delete(model);   
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRole(ServiceEditUserRoleDto model)
        {
            var result = await _userService.EditUserRoles(model.userId,model.roles);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
  

    }
}
