using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductCategoryDto;
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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {

            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IResponse<ProductCategory>> InsertAsync(ServiceCreateProductCategoryDto createDto)
        {


            var product = new ProductCategory()
            {
                Title = createDto.Title,

            };

            var result = await _productCategoryRepository.Insert(product);
            await _productCategoryRepository.SaveChanges();
            return result;

        }
        public async Task<ServiceSelectProductCategoryDto> SelectAsync(string searchString, int pageSize, int pageIndex)
        {
            var productCategory = await _productCategoryRepository.Search(searchString, pageSize, pageIndex);

            ServiceSelectProductCategoryDto serviceSearchProductDto = new ServiceSelectProductCategoryDto() { productCategory = productCategory.Result };

            return serviceSearchProductDto;

        }
        public async Task<IResponse<ProductCategory>> UpdateAsync(ServiceUpdateProductCategoryDto updateDto)
        {
            var product = new ProductCategory()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
            };

           var result=await _productCategoryRepository.Upadate(product, updateDto.Id);
            await _productCategoryRepository.SaveChanges();
            return result;
        }
        public async Task<IResponse<ProductCategory>> DeleteAsync(ServiceDeleteProductCategoryDto deleteByIdDto)
        {

            var result= await _productCategoryRepository.DeleteById(deleteByIdDto.Id);
            await _productCategoryRepository.SaveChanges();
            return result;

        }

    }
}
