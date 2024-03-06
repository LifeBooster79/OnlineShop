using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Framework.Bases
{
    public class BaseService<TEntitiy> where TEntitiy : class
    {
        private readonly IRepository<TEntitiy> _productRepository;

        public BaseService(IRepository<TEntitiy> productRepository)
        {
            _productRepository = productRepository;
        }


    }
}
