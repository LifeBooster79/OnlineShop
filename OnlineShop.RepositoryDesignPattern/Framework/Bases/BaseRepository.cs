using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using ResponseFramework;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using System.Net.NetworkInformation;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;

namespace OnlineShop.RepositoryDesignPattern.Framework.Bases
{
    public abstract class BaseRepository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class where TDbContext : IdentityDbContext<OnlineShopUser, OnlineShopRole, string,
                                                                       IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
                                                                       IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        protected virtual TDbContext DbContext { get; set; }
        protected virtual DbSet<TEntity> DbSet { get; set; }

        public BaseRepository(TDbContext dbContext)
        {

            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();

        }

        //Insert Item
        public virtual async Task<IResponse<TEntity>> Insert(TEntity entity)
        {
            var response = new Response<TEntity>();
            try
            {

                if (entity is null)
                {
                    response.Message = $"Cant Delete In Product Table";
                    response.IsSuccessful = false;
                }
                else
                {
                    await DbSet.AddAsync(entity);
                    await SaveChanges();
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //SelectAll Items
        public virtual async Task<IResponse<IEnumerable<TEntity>>> SelectAll()
        {
            var response = new Response<IEnumerable<TEntity>>();
            try
            {
                var list = await DbSet.ToListAsync();

                if (list is null)
                {
                    response.Message = $"Cant SelectAll Product Table";
                    response.IsSuccessful = false;
                }
                else
                {
                    response.Result = list;
                    response.IsSuccessful = true;

                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update Item
        public virtual async Task<IResponse<TEntity>> Upadate(TEntity entity)
        {
            var response = new Response<TEntity>();
            try
            {

                if (entity is null)
                {
                    response.Message = $"Cant Update In Product Table";
                    response.IsSuccessful = false;
                }
                else
                {
                    DbSet.Update(entity);
                    await SaveChanges();
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Delete Item
        public virtual async Task<IResponse<TEntity>> Delete(TEntity entity)
        {
            var response = new Response<TEntity>();
            try
            {

                if (entity is null)
                {
                    response.Message = $"Cant Delete In Product Table";
                    response.IsSuccessful = false;
                }
                else
                {
                    DbSet.Remove(entity);
                    await SaveChanges();
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
