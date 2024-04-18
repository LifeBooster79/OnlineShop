using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.OrderDto
{
    public class ServiceOrderDetailsDto
    {
        // Properties of OrderDetail
        public Guid productId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        // Other properties of OrderDetail
    }
}
