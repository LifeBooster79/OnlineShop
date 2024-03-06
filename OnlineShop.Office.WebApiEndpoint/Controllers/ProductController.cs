using Microsoft.AspNetCore.Http;
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
        [Route("api/[controller]/Create")]
        public async Task<IActionResult> Create([FromBody] ServiceCreateProductDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.InsertAsync(createDto);
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ReadAll")]
        public async Task<IActionResult> SelectAll()
        {
                var response=await _productService.SelectAllAsync();
                return Ok(response);
        }

        [HttpPost]
        [Route("api/[controller]/Update")]
        public async Task<IActionResult> Upadte([FromBody] ServiceUpdateProductDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.Update(updateDto);
                return Ok();
            }
        }

        [HttpPost]
        [Route("api/[controller]/Delete")]
        public async Task<IActionResult> Delete([FromBody] ServiceDeleteProductDto deleteDto)
        {
            if (deleteDto == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.Delete(deleteDto);   
                return Ok();
            }
        }
    }
}
