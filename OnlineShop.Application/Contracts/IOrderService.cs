using OnlineShop.Application.Dtos.OrderDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.RepositoryDesignPattern.Services.Dtos;
using ResponseFramework;

namespace OnlineShop.Application.Contracts
{
    public interface IOrderService
    {
        Task<IResponse<string>> InsertAsync(ServiceCreateOrderDto createDto, string seller, string buyyer);
        Task<IResponse<IEnumerable<OrderHeader>>> SelectOrderAsync(string id);
        Task<IResponse<IEnumerable<OrderDetail>>> SelectOrderDetialsASync(Guid searchString, int pageSize, int pageIndex);
        Task<IResponse<string>> UpdateAsync(ServiceUpdateOrderDto updateDto);
        Task<IResponse<string>> DeleteAsync(ServiceDeleteOrderDto deleteOrderDto);
    }
}