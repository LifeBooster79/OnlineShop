using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) {

            _productService = productService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Create([FromBody] ServiceCreateProductDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.InsertAsync(model);
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Read(string? searchString,int pageIndex,int pageSize)
        {

            var response=await _productService.SelectAsync(searchString,pageSize,pageIndex);
            return Ok(response.products);

        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> Upadte([FromBody] ServiceUpdateProductDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.UpdateAsync(updateDto);
                return Ok();
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public async Task<IActionResult> Delete([FromBody] ServiceDeleteByIdProductDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.DeleteAsync(model);
                return Ok();
            }
        }
    }
}
