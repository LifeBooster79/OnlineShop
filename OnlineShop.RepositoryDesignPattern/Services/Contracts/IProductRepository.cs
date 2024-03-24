using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using ResponseFramework;

namespace OnlineShop.RepositoryDesignPattern.Services.Contracts
{
    public interface IProductRepository:IRepository<Product,Guid>
    {
        Task<IResponse<IEnumerable<Product>>> Search(string searchString, int pageSize, int pageIndex);
    }
}