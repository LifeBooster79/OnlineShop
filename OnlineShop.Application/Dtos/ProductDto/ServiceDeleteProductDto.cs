using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductDto
{
    public class ServiceDeleteProductDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required decimal UnitPrice { get; set; }
        public required string Code { get; set; }
        public required Guid productCategoryId { get; set; }

    }
}
