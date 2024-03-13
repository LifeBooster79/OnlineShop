using OnlineShop.Application.Dtos.ProductCategoryDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.SaleService
{
    public class ProductCategoryService
    {
        private readonly IRepository<ProductCategory,Guid> _productCategoryRepository;

        public ProductCategoryService(IRepository<ProductCategory,Guid> productCategoryRepository)
        {

            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IResponse<ProductCategory>> InsertAsync(ServiceCreateProductCategoryDto createDto)
        {


            var product = new ProductCategory()
            {
                Title = createDto.Title,

            };

            return await _productCategoryRepository.Insert(product);

        }
    }
}
