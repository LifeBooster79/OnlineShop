using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Framework.Bases;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using PublicTools.DbConstants.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories
{
    public class UserRepository:BaseRepository<OnlineShopUser,OnlineShopDbContext, Guid>, IUserRepository
    {
        public UserRepository(OnlineShopDbContext context) : base(context)
        {


        }
    }
}
