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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] ServiceCreateUserDto userDto)
        {
            var result = await _userService.Register(userDto);

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
        [Route("/api/[controller]/Login")]
        public async Task<IActionResult> LoginUser([FromBody] ServiceLoginDto model)
        {
            var token = await _userService.Login(model);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }



        [HttpDelete]

        public async Task<IActionResult> Delete(string id)
        {
            var result=await _userService.Delete(id);   
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        //[HttpPut]
        //public async Task<IActionResult> EditUserRoles(string userId, List<string> roles)
        //{

        //    var user = await _userManager.FindByIdAsync(userId);
        //    var currentRoles = await _userManager.GetRolesAsync(user);
        //    foreach (var item in currentRoles)
        //    {
        //        if (!roles.Any(c => c == item))
        //        {
        //            var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, item);
        //        }
        //    }
        //    foreach (var item in roles)
        //    {
        //        var isInRole = await _userManager.IsInRoleAsync(user, item);
        //        if (!isInRole)
        //        {
        //            var result=await _userManager.AddToRoleAsync(user, item);
        //            if(!result.Succeeded)
        //            {
        //                return BadRequest(result.Errors);
        //            }
        //        }
        //    }

        //    return Ok(user);


        //}


    }
}
