using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<OnlineShopUser> _userManager;

        public UserController(UserManager<OnlineShopUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] ServiceCreateUserDto userDto)
        {
            var user = new OnlineShopUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditUserRoles(string userId, List<string> roles)
        {

            var user = await _userManager.FindByIdAsync(userId);
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
                    var result=await _userManager.AddToRoleAsync(user, item);
                    if(!result.Succeeded)
                    {
                        return BadRequest(result.Errors);
                    }
                }
            }

            return Ok(user);


        }


    }
}
