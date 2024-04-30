using OnlineShop.Application.Dtos.ProductCategoryDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;

namespace OnlineShop.Application.Services.SaleService
{
    public interface IProductCategoryService
    {
        Task<IResponse<ProductCategory>> InsertAsync(ServiceCreateProductCategoryDto createDto);
        Task<ServiceSelectProductCategoryDto> SelectAsync(string searchString, int pageSize, int pageIndex);
        Task<IResponse<ProductCategory>> UpdateAsync(ServiceUpdateProductCategoryDto updateDto);
        Task<IResponse<ProductCategory>> DeleteAsync(ServiceDeleteProductCategoryDto deleteByIdDto);
        
        
        
    }
}