using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.OrderDto
{
    public class ServiceDeleteOrderDto
    {
        public required Guid orderHeaderId { get; set; }
    }
}
