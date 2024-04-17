using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using ResponseFramework;

namespace OnlineShop.RepositoryDesignPattern.Services.Contracts
{
    public interface IUserRepository: IRepository<OnlineShopUser,Guid>
    {
        
    }
}