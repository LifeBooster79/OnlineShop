using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Services.Dtos;
using ResponseFramework;

namespace OnlineShop.RepositoryDesignPattern.Services.Contracts
{
    public interface IOrderRepository
    {
        Task<IResponse<string>> Insert(OrderHeader entity);
        Task<IResponse<IEnumerable<OrderHeader>>> SelectOrder(string id);
        //Task<IResponse<IEnumerable<OrderHeader>>> SelectOrder(string searchId, int pageSize, int pageIndex);
        Task<IResponse<IEnumerable<OrderDetail>>> SelectOrderDetail(Guid searchId, int pageSize, int pageIndex);
        Task<IResponse<string>> Update(OrderHeader orderHeader);
        Task<IResponse<String>> Delete(Guid orderHeaderId);
        Task SavaeChanges();
    }
}