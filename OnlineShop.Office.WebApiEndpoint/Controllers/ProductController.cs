using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ServiceCreateProductDto createdto)
        {
            if (createdto != null)
            {
                ServiceCreateProductDto serviceCreateProductDto = new ServiceCreateProductDto()
                {
                    Id = createdto.Id,
                    Title = createdto.Title,
                    UnitPrice = createdto.UnitPrice,
                };

                var response=await _productService.InsertAsync(serviceCreateProductDto);

                return Json(response.IsSuccessful);
            }
            else
            {
                return Json("Cant Added");
            }
        }

        public async Task<IActionResult> GetAllProducts()
        {
            ServiceSelectAllProductDto products = await _productService.SelectAllAsync();


            return Json(products.ServiceSelectProductDtoList);
        }
    }
}
