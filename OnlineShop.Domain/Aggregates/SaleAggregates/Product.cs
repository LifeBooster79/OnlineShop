using OnlineShop.Domain.Aggregates.Framework.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class Product:MainEntity
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string Code {  get; set; }
        public  Guid productCategoryId { get; set; }
        [ForeignKey("productCategoryId")]
        public ProductCategory productCategory { get; set; }
    }
}
