using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
