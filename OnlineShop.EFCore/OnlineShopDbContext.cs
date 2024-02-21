using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.Domain.Aggregates.OrderAggregates;
using System.Reflection.Emit;


namespace OnlineShop.EFCore
{
    public class OnlineShopDbContext: IdentityDbContext<OnlineShopUser,OnlineShopRole, string,
        IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }
    }
}
