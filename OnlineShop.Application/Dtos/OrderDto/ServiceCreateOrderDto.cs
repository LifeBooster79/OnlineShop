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
        public ServiceOrderHeaderDto OrderHeader { get; set; }
        public List<ServiceOrderDetailsDto> OrderDetails { get; set; }
    }


}
