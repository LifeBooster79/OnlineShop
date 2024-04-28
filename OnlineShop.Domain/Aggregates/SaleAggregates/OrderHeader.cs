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
        public DateTime OrderDate { get; set; }

        // Foreign key for Seller
        public string? SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual OnlineShopUser Seller { get; set; }

        // Foreign key for Buyer
        public string? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual OnlineShopUser Buyer { get; set; }

    }
}
