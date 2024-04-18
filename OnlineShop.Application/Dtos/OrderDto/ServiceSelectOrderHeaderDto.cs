using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.OrderDto
{
    public class ServiceSelectOrderHeaderDto
    {
        public IEnumerable<OrderHeader> orderHeder { get; set; }
    }
}
