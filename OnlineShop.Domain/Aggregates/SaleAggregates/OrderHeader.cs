using OnlineShop.Domain.Aggregates.Framework.Base;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderHeader:MainEntity
    {
        public Guid Id { get; set; }
        public string SellerId { get; set; }
        public string BuyerId { get; set; }
        public DateTime OrderDate { get; set; }
        // Foreign key properties
        [ForeignKey("SellerId")]
        public  OnlineShopUser Seller { get; set; }
        [ForeignKey("BuyerId")]
        public OnlineShopUser Buyer { get; set; }
    }
}
