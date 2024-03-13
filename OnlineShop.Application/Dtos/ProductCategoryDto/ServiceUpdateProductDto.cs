using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductCategoryDto
{
    public class ServiceUpdateProductCategoryDto
    {
        public required string Title { get; set; }

    }
}
