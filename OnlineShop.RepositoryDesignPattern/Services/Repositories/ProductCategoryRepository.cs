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
    public class ProductCategoryRepository: BaseRepository<ProductCategory, OnlineShopDbContext, Guid>, IProductCategoryRepository
    {
        public ProductCategoryRepository(OnlineShopDbContext context) : base(context)
        {


        }

        public virtual async Task<IResponse<IEnumerable<ProductCategory>>> Search(string searchString, int pageSize, int pageIndex)
        {
            var response = new Response<IEnumerable<ProductCategory>>();

            try
            {
                var productCategory = DbSet.Select(p => p);

                if (!String.IsNullOrEmpty(searchString))
                {

                    productCategory = DbSet.Where(p => p.Title.Contains(searchString));
                }


                productCategory = productCategory.Skip((pageIndex - 1) * pageSize).Take(pageSize);

                response.Result = await productCategory.ToListAsync();
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
