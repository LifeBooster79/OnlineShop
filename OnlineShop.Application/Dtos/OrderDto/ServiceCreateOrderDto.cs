using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.OrderDto
{
    public class ServiceCreateOrderDto
    {
        public OrderHeaderDto OrderHeader { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }

    public class OrderHeaderDto
    {
        // Properties of OrderHeader
        public required string Seller { get; set; }
        public required string Buyer { get; set; }
        // Other properties of OrderHeader
    }

    public class OrderDetailDto
    {
        // Properties of OrderDetail
        public Guid productId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        // Other properties of OrderDetail
    }

}
