using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.UserManagementConfigurations
{
    public class OnlineShopRoleConfiguration: IEntityTypeConfiguration<OnlineShopRole>
    {
        public void Configure(EntityTypeBuilder<OnlineShopRole> builder)
        {

        }
    }
}
