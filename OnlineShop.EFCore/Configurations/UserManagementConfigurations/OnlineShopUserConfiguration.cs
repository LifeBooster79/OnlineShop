using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using PublicTools.DbConstants.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.UserManagementConfigurations
{
    public class OnlineShopUserConfiguration: IEntityTypeConfiguration<OnlineShopUser>
    {
        public void Configure(EntityTypeBuilder<OnlineShopUser> builder)
        {
            //builder.Property(p => p.CellPhone).IsRequired();
            //builder.HasIndex(p => p.CellPhone).IsUnique();

            //builder.Property(p => p.NationalId).IsRequired();
            //builder.HasIndex(p => p.NationalId).IsUnique();
            //builder.Property(p => p.NationalIdConfirmed).HasDefaultValue(false);

            //builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
            //builder.Property(p => p.DateCreatedLatin).IsRequired().HasDefaultValue(System.DateTime.Now);
            //builder.Property(p => p.IsModified).HasDefaultValue(false);
            //builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }

    }
}
