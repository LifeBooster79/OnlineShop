using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;

namespace OnlineShop.Application.Contracts
{
    public interface IProductService
    {
        Task<IResponse<Product>> InsertAsync(ServiceCreateProductDto createDto);
        Task<ServiceSelectProductDto> SelectAsync(string searchString, int pageSize, int pageIndex);
        Task UpdateAsync(ServiceUpdateProductDto updateDto);
        Task DeleteAsync(ServiceDeleteByIdProductDto deleteByIdDto);
        
    }
}