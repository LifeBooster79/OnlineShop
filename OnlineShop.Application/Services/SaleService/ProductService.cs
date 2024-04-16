using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.SaleService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
        public async Task<IResponse<Product>> InsertAsync(ServiceCreateProductDto createDto)
        {


            var product = new Product()
            {
                Title = createDto.Title,
                UnitPrice = createDto.UnitPrice,
                Code = createDto.Code,
                productCategoryId=createDto.productCategoryId

            };

            return await _productRepository.Insert(product);


        }
        public async Task<ServiceSelectProductDto> SelectAsync(string searchString, int pageSize, int pageIndex)
        {
            var products = await _productRepository.Search(searchString, pageSize, pageIndex);

            ServiceSelectProductDto serviceSearchProductDto = new () { products = products.Result };

            return serviceSearchProductDto;

        }
        public async Task UpdateAsync(ServiceUpdateProductDto updateDto)
        {
            var product = new Product()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                UnitPrice = updateDto.UnitPrice,
                Code = updateDto.Code,
                productCategoryId = updateDto.productCategoryId,

            };

            await _productRepository.Upadate(product,updateDto.Id);
        }
        public async Task DeleteAsync(ServiceDeleteByIdProductDto deleteByIdDto)
        {

            await _productRepository.DeleteById(deleteByIdDto.Id);
        }


    }
}
