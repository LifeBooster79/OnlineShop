using OnlineShop.Domain.Aggregates.ProductAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.OrderAggregates
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid? OrderHeaderId { get; set; }
        public Guid? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public OrderHeader? OrderHeader { get; set; }
        public Product? Product { get; set; }
    }
}
