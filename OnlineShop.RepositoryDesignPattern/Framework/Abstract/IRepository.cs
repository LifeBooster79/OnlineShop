using ResponseFramework;

namespace OnlineShop.RepositoryDesignPattern.Framework.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IResponse<TEntity>> Delete(TEntity entity);
        Task<IResponse<TEntity>> Insert(TEntity entity);
        Task<IResponse<IEnumerable<TEntity>>> SelectAll();
        Task<IResponse<TEntity>> Upadate(TEntity entity);
        Task SaveChanges();
    }
}