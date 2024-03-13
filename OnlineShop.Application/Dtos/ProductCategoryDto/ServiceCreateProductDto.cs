using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductCategoryDto
{
    public class ServiceCreateProductCategoryDto
    {
        public required string Title { get; set; }
    }
}
