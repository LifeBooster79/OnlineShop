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
    public abstract class BaseRepository<TEntity, TDbContext,TPrimaryKey> : IRepository<TEntity,TPrimaryKey> where TEntity : class where TDbContext : IdentityDbContext<OnlineShopUser, OnlineShopRole, string,
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
                var list =await DbSet.AsNoTracking().ToListAsync();

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

        //Update
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

        //DeleteByID
        public virtual async Task<IResponse<TEntity>> UpadateById(TPrimaryKey Id)
        {
            try
            {
                var response = await FindById(Id);

                if (response.IsSuccessful == true)
                {
                    DbSet.Update(response.Result);
                    await SaveChanges();
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Delete
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

        //DeleteByID
        public virtual async Task<IResponse<TEntity>> DeleteById(TPrimaryKey Id)
        {
            try
            {
                var response = await FindById(Id);

                if (response.IsSuccessful == true)
                {
                   DbSet.Remove(response.Result);
                   await SaveChanges();
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //FindById
        public virtual async Task<IResponse<TEntity>> FindById(TPrimaryKey id)
        {
            var response = new Response<TEntity>();
            try
            {

                var enitity = await DbSet.FindAsync(id);
                if (enitity == null)
                {
                    response.Message = "Cant Find In Table";
                    response.IsSuccessful = false;

                }
                else
                {
                    response.Result = enitity;
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch(Exception)
            {

                throw;

            }
           
        }
        
        //SaveChanges
        public async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
