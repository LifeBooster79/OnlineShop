using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductDto
{
    public class ServiceCreateProductDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter Unit Price")]
        public decimal UnitPrice { get; set; }
    }
}
