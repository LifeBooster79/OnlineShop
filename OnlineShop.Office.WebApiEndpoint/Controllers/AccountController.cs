using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.UserDto;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] ServiceCreateUserDto userDto)
        {
            var result = await _accountService.Register(userDto);

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
            var token = await _accountService.Login(model);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}
