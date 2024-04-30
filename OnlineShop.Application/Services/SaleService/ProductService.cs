using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

            var result=await _productRepository.Insert(product);
            await _productRepository.SaveChanges();
            return result;  


        }
        public async Task<ServiceSelectProductDto> SelectAsync(string searchString, int pageSize, int pageIndex)
        {
            var products = await _productRepository.Search(searchString, pageSize, pageIndex);

            if(products.Result!=null)
            products.Result=products.Result.Where(p => p.IsSoftDeleted != true);

            ServiceSelectProductDto serviceSearchProductDto = new () { products = products.Result };

            return serviceSearchProductDto;

        }
        public async Task<IResponse<Product>> UpdateAsync(ServiceUpdateProductDto updateDto)
        {
            //Convert to PersianTime
            //-----------------------------------------------------
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime dateTime = DateTime.Now;

            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            string persianDateTimeString = $"{year}/{month}/{day}";
            //-----------------------------------------------------


            var product = new Product()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                UnitPrice = updateDto.UnitPrice,
                Code = updateDto.Code,
                productCategoryId = updateDto.productCategoryId,
                isModified=true,
                ModifyDatePersian= persianDateTimeString


            };

            var result=await _productRepository.Upadate(product,updateDto.Id);
            await _productRepository.SaveChanges();
            return result;

         
        }
        public async Task<IResponse<Product>> DeleteAsync(ServiceDeleteByIdProductDto deleteByIdDto)
        {
            //Convert to PersianTime
            //-----------------------------------------------------
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime dateTime = DateTime.Now;

            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            string persianDateTimeString = $"{year}/{month}/{day}";
            //-----------------------------------------------------

            var product = new Product()
            {
                
                IsSoftDeleted = true,
                SoftDeleteDatePersian= persianDateTimeString
            };

            var result=await _productRepository.Upadate(product, deleteByIdDto.Id);
            result.Message = "Successfully Deleted";
            await _productRepository.SaveChanges();
            return result;
        }


    }
}
