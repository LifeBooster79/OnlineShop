using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductDto
{
    public class ServiceUpdateProductDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string Code { get; set; }
        public ProductCategory productCategory { get; set; }
    }
}
