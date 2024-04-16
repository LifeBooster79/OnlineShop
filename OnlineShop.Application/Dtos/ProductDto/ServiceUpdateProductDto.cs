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
        public required Guid Id { get; set; }
        public  string? Title { get; set; }
        public  decimal UnitPrice { get; set; }
        public  string? Code { get; set; }
        public  Guid productCategoryId { get; set; }
    }
}
