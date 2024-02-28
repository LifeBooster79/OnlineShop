using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using System.Reflection;


namespace OnlineShop.EFCore
{
    public class OnlineShopDbContext: IdentityDbContext<OnlineShopUser,OnlineShopRole, string,
        IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
            
        }

        #region [- OnModelCreating(ModelBuilder modelBuilder) -]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region [- ApplyConfigurationsFromAssembly() -]
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #endregion


    }
}
