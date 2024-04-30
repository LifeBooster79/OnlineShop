using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;

namespace OnlineShop.Application.Contracts
{
    public interface IProductService
    {
        Task<IResponse<Product>> InsertAsync(ServiceCreateProductDto createDto);
        Task<ServiceSelectProductDto> SelectAsync(string searchString, int pageSize, int pageIndex);
        Task<IResponse<Product>> UpdateAsync(ServiceUpdateProductDto updateDto);
        Task<IResponse<Product>> DeleteAsync(ServiceDeleteByIdProductDto deleteByIdDto);


    }
}