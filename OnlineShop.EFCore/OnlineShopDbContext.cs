using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.Domain.Aggregates.OrderAggregates;
using System.Reflection.Emit;
using OnlineShop.Domain.Aggregates.ProductAggregates;


namespace OnlineShop.EFCore
{
    public class OnlineShopDbContext: IdentityDbContext<OnlineShopUser,OnlineShopRole, string,
        IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> categories { get; set; }
        public DbSet<OrderHeader> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }


    }
}
