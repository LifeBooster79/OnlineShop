using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.OrderDto
{
    public class ServiceOrderHeaderDto
    {
        // Properties of OrderHeader
        public required string Seller { get; set; }
        public required string Buyer { get; set; }
        // Other properties of OrderHeader
    }
}
