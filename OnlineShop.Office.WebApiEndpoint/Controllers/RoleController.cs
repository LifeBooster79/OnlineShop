using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.RoleDto;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRole(ServiceCreateRoleDto createRoleModel)
        {
            var result = await _roleService.RegisterRole(createRoleModel);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result=await _roleService.GetRoles();
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
        public async Task<IActionResult> Delete(ServiceDeleteRoleDto model)
        {
            var result = await _roleService.Delete(model.Id);
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
