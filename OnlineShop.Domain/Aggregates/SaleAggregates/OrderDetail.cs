using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderDetail
    {
        public Guid orderHeaderId { get; set; }
        public Guid productId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey("orderHeaderId")]
        public OrderHeader OrderHeader { get; set; }
        [ForeignKey("productId")]
        public Product Product { get; set; }
    }
}
