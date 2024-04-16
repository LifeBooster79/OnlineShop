using OnlineShop.Application.Dtos.ProductCategoryDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;

namespace OnlineShop.Application.Services.SaleService
{
    public interface IProductCategoryService
    {
        Task DeleteAsync(ServiceDeleteProductCategoryDto deleteByIdDto);
        Task<IResponse<ProductCategory>> InsertAsync(ServiceCreateProductCategoryDto createDto);
        Task<ServiceSelectProductCategoryDto> SelectAsync(string searchString, int pageSize, int pageIndex);
        Task UpdateAsync(ServiceUpdateProductCategoryDto updateDto);
    }
}