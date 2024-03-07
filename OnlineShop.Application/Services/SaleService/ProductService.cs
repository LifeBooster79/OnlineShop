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
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {

            _productRepository = productRepository;
        }
        public async Task<IResponse<Product>> InsertAsync(ServiceCreateProductDto createDto)
        {
            var  category=new ProductCategory()
            {
                Id= createDto.productCategoryId,
            }

            var product = new Product()
            {
                Id = createDto.Id,
                Title = createDto.Title,
                UnitPrice = createDto.UnitPrice,
                Code = createDto.Code,
                productCategoryId=createDto.productCategoryId
            };

            return await _productRepository.Insert(product);


        }

        public async Task<ServiceSelectAllProductDto> SelectAllAsync()
        {

            var products = await _productRepository.SelectAll();

            ServiceSelectAllProductDto serviceSelectAllProductDto = new ServiceSelectAllProductDto();

            foreach (var product in products.Result)
            {
                serviceSelectAllProductDto.ServiceSelectProductDtoList.Add(new ServiceSelectProductDto()
                {
                    Id = product.Id,
                    Title = product.Title,
                    UnitPrice = product.UnitPrice,
                });
            }

            return serviceSelectAllProductDto;

        }

        public async Task Update(ServiceUpdateProductDto updateDto)
        {
            var product = new Product()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                UnitPrice = updateDto.UnitPrice,
            };

            await _productRepository.Upadate(product);
        }


        public async Task Delete(ServiceDeleteProductDto deleteDto)
        {
            var product = new Product()
            {
                Id = deleteDto.Id,
                Title = deleteDto.Title,
                UnitPrice = deleteDto.UnitPrice,
            };

            await _productRepository.Delete(product);
        }
    }
}
