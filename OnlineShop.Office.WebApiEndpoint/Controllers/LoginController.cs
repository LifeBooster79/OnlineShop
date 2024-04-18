using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.LogDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<OnlineShopUser> _signInManager;

        private readonly UserManager<OnlineShopUser> _userManager;


        public LoginController(SignInManager<OnlineShopUser> signInManager, UserManager<OnlineShopUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(ServiceLoginDto loginDto)
        {
 
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password,loginDto.RememberMe,false);

            if(result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
