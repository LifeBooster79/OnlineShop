using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
