using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using ResponseFramework;

namespace OnlineShop.Application.Contracts
{
    public interface IUserService
    {
        Task<IResponse<OnlineShopUser>> InsertAsync(ServiceCreateUserDto createDto);
    }
}