using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using PublicTools.DbConstants.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class ProductCategoryConfigurations: IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(OrderDetail), Sales.schemaName);
            builder.HasKey(p => new
            {
                p.Id
            });
        }
    }
}
