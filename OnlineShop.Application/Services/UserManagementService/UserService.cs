using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Application.Dtos.UserDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.UserManagementService
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }
        public async Task<IResponse<OnlineShopUser>> InsertAsync(ServiceCreateUserDto createDto)
        {


            var user = new OnlineShopUser()
            {
                UserName = createDto.UserName,
                PasswordHash = createDto.Password,
                Email = createDto.Email,
                EmailConfirmed = false,
                PhoneNumber = createDto.PhoneNumber,
                PhoneNumberConfirmed=false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            return await _userRepository.Insert(user);

        }
    }
}
