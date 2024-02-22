using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderHeader
    {
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public  OnlineShopUser Seller { get; set; }
        public OnlineShopUser Buyer { get; set; }
        //public List<OrderDetail>? OrderDetails { get; set; }
    }
}
