using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.OrderDto;
using OnlineShop.Application.Dtos.ProductCategoryDto;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Services.SaleService;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<OnlineShopUser> _userManager;
        private readonly IOrderService _orderService;
        public OrderController(UserManager<OnlineShopUser> userManager,IOrderService orderService)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceCreateOrderDto model)
        {
            if (model.OrderHeader.Seller!=null && model.OrderHeader.Buyer!=null)
            {

                var result=await _orderService.InsertAsync(model, model.OrderHeader.Seller, model.OrderHeader.Buyer);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet]
        public async Task<IActionResult> SelectOrder([FromBody] ServiceSelectOrderDto model)
        {
            var result = await _orderService.SelectOrderAsync(model.id);

            return Ok(result);
            
        }

        [HttpGet]
        [Route("/api/OrderDetails")]
        public async Task<IActionResult> SelectOrderDetail(Guid searchString, int pageSize, int pageIndex)
        {

            var result = await _orderService.SelectOrderDetialsASync(searchString, pageSize, pageIndex);

            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> Upadte([FromBody] ServiceUpdateOrderDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }
            else
            {
                var result=await _orderService.UpdateAsync(updateDto);
                return Ok(result);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ServiceDeleteOrderDto model)
        {
            if (model!=null)
            {

                var result = await _orderService.DeleteAsync(model);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
