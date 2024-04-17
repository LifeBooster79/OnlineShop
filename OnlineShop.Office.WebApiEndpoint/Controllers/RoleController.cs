using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.RoleDto;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<OnlineShopRole> _roleManager;

        public RoleController(RoleManager<OnlineShopRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRole(ServiceCreateRoleDto createRoleModel)
        {

            var role = new OnlineShopRole
            {
                Name = createRoleModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(result.Errors);
            };

        }


    }
}
