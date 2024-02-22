using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderDetail
    {
        public string? OrderHeaderId { get; set; }
        public string? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public OrderHeader? OrderHeader { get; set; }
        public Product? Product { get; set; }
    }
}
