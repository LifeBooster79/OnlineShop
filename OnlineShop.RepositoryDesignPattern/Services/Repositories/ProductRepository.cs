using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Framework.Bases;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories
{
    public class ProductRepository:BaseRepository<Product,OnlineShopDbContext,Guid>,IProductRepository
    {
        public ProductRepository(OnlineShopDbContext context) : base(context) { 
        
            
              
        }

        public virtual async Task<IResponse<IEnumerable<Product>>> Search(string searchString,int pageSize,int pageIndex)
        {
            var response = new Response<IEnumerable<Product>>();

            try
            {
                var products =await DbSet.Where(p=>p.Title.Contains(searchString)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                response.Result = products;
                response.IsSuccessful = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
