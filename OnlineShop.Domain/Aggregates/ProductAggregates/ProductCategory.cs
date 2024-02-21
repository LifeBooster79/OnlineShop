using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.ProductAggregates
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Product>? Products { get; set; }
    }
}
