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
        public async Task<IActionResult> SelectAll()
        {
                var response=await _productService.SelectAllAsync();
                return Ok(response.serviceSelectProductDtoList);
        }

        [HttpGet]
        [Route("api/[controller]/filter")]
        public async Task<IActionResult> Search(string searchString,int pageIndex,int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var response=await _productService.Search(searchString,pageSize,pageIndex);
                return Ok(response.products);

            }else { return BadRequest(); }
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
                await _productService.Update(updateDto);
                return Ok();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]
        public async Task<IActionResult> Delete([FromBody] ServiceDeleteProductDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.Delete(model);   
                return Ok();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteById")]
        public async Task<IActionResult> DeleteById([FromBody] ServiceDeleteByIdProductDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                await _productService.DeleteById(model);
                return Ok();
            }
        }
    }
}
