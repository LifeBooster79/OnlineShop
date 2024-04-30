using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Dtos
{
    public class OrderHeaderDetailDto
    {
        public OrderHeader orderHeader { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
