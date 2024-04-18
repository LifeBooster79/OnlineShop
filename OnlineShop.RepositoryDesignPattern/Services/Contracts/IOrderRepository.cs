using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;

namespace OnlineShop.RepositoryDesignPattern.Services.Contracts
{
    public interface IOrderRepository
    {
        Task<IResponse<string>> Insert(OrderHeader entity, List<OrderDetail> details);
        Task<IResponse<IEnumerable<OrderHeader>>> SelectOrder(string searchId, int pageSize, int pageIndex);
        Task<IResponse<IEnumerable<OrderDetail>>> SelectOrderDetail(Guid searchId, int pageSize, int pageIndex);
        Task<IResponse<string>> Update(OrderDetail updatedEntity, Guid orderHeaderId, Guid productId);
        Task<IResponse<String>> Delete(Guid orderHeaderId);
    }
}