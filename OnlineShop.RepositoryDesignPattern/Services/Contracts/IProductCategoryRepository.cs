using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Contracts
{
    public interface IProductCategoryRepository: IRepository<ProductCategory, Guid>
    {
        Task<IResponse<IEnumerable<ProductCategory>>> Search(string searchString, int pageSize, int pageIndex);
    }
}
