using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductDto
{
    public class ServiceUpdateProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
