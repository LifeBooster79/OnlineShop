using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;

namespace OnlineShop.Application.Contracts
{
    public interface IProductService
    {
        Task Delete(ServiceDeleteProductDto deleteDto);
        Task<IResponse<Product>> InsertAsync(ServiceCreateProductDto createDto);
        Task<ServiceSelectAllProductDto> SelectAllAsync();
        Task Update(ServiceUpdateProductDto updateDto);
    }
}