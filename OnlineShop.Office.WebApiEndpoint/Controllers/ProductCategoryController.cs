using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductCategoryDto;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Services.SaleService;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {

            _productCategoryService = productCategoryService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Create([FromBody] ServiceCreateProductCategoryDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                var result=await _productCategoryService.InsertAsync(model);
                return Ok(result);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Read(string? searchString, int pageIndex, int pageSize)
        {

            var response = await _productCategoryService.SelectAsync(searchString, pageSize, pageIndex);
            return Ok(response.productCategory);

        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> Upadte([FromBody] ServiceUpdateProductCategoryDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }
            else
            {
                var result=await _productCategoryService.UpdateAsync(updateDto);
                return Ok(result);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public async Task<IActionResult> Delete([FromBody] ServiceDeleteProductCategoryDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                var result=await _productCategoryService.DeleteAsync(model);
                return Ok(result);
            }
        }
    }
}
