using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Framework.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories
{
    public class ProductRepository:BaseRepository<Product,OnlineShopDbContext>
    {
        public ProductRepository(OnlineShopDbContext context) : base(context) { 
        
            
            
            
        }
    }
}
