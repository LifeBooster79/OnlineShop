using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShopDbContext _context;
        public OrderRepository(OnlineShopDbContext context)
        {

            _context = context;

        }

        public virtual async Task<IResponse<String>> Insert(OrderHeader entity, List<OrderDetail> details)
        {
            var response = new Response<String>();

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {


                    if (entity == null || details == null)
                    {
                        response.Message = "Cant Add In Table";
                        response.IsSuccessful = false;

                    }
                    else
                    {

                        var result = await _context.OrderHeader.AddAsync(entity);

                        foreach (OrderDetail detail in details)
                        {
                            await _context.OrderDetail.AddAsync(detail);

                        }
                        response.Message = "The Order Added";
                        response.Result = null;
                        response.IsSuccessful = true;

                        await _context.SaveChangesAsync();
                        scope.Complete()
;
                    }

                    return response;

                }
                catch (Exception ex)
                {
                    
                    scope.Dispose();
                    throw;
                }

            }
   
        }
        public virtual async Task<IResponse<IEnumerable<OrderHeader>>> SelectOrder(string searchId, int pageSize, int pageIndex)
        {
            var response = new Response<IEnumerable<OrderHeader>>();


            var orderHeader = _context.OrderHeader.Select(o => o);
            if (searchId != null)
            {

                orderHeader = orderHeader.Where(o => o.SellerId == searchId || o.BuyerId == searchId);
            }
            orderHeader = orderHeader.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            if (orderHeader == null)
            {

                response.Message = "Cant Find The Order";
                response.Result = null;
                response.IsSuccessful = false;
            }
            else
            {
                response.Message =null;
                response.Result = await orderHeader.ToListAsync();
                response.IsSuccessful = true;
            }

            return response;
        }

        public virtual async Task<IResponse<IEnumerable<OrderDetail>>> SelectOrderDetail(Guid searchId, int pageSize, int pageIndex)
        {
            var response = new Response<IEnumerable<OrderDetail>>();

            var orderDetails = _context.OrderDetail.Select(o=>o);
            if (searchId != Guid.Empty)
            {

                orderDetails = orderDetails.Where(o => o.orderHeaderId == searchId || o.productId == searchId);
            }
            orderDetails = orderDetails.Skip((pageIndex - 1) * pageSize).Take(pageSize);


            if (orderDetails == null)
            {

                response.Message = "Cant Find The OrderDetials";
                response.Result = null;
                response.IsSuccessful = false;
            }
            else
            {
                response.Message = null;
                response.Result = await orderDetails.ToListAsync();
                response.IsSuccessful = true;
            }

            return response;

        }
        public virtual async Task<IResponse<string>> Update(OrderDetail updatedEntity, Guid orderHeaderId,Guid productId)
        {
            var response = new Response<string>();
            try
            {
                var entity = await _context.OrderDetail.FirstOrDefaultAsync(o=>o.productId==productId && o.orderHeaderId==orderHeaderId);

                if (entity is null)
                {
                    response.Message = "Cant Find In Table";
                    response.IsSuccessful = false;
                }
                else
                {
                    foreach (var property in typeof(OrderDetail).GetProperties())
                    {
                        // Get the type of the property
                        var propertyType = property.PropertyType;

                        var updatedValue = property.GetValue(updatedEntity);

                        //Check Null Property
                        if (propertyType.Name == "String" && updatedValue != null)
                        {
                            property.SetValue(entity, updatedValue);
                        }
                        else
                        {
                            //Check Decimal Property
                            if (propertyType.Name == "Decimal")
                            {
                                if (Convert.ToInt32(updatedValue) != 0)
                                {
                                    property.SetValue(entity, updatedValue);
                                }
                            }
                            //Check Guid Propery
                            if (propertyType.Name == "Guid")
                            {
                                if ((Guid)updatedValue != Guid.Empty)
                                {
                                    property.SetValue(entity, updatedValue);
                                }
                            }
                        }
                    }
                    _context.OrderDetail.Update(entity);
                    await _context.SaveChangesAsync();
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<IResponse<String>> Delete(Guid orderHeaderId)
        {
            using (TransactionScope scope=new TransactionScope())
            {
                try
                {
                    var response = new Response<String>();

                    var orderHeader = await _context.OrderHeader.FindAsync(orderHeaderId);

                    var orderDetails = _context.OrderDetail.Where(o => o.orderHeaderId == orderHeaderId);

                    // Remove all related OrderDetails
                    _context.OrderDetail.RemoveRange(orderDetails);

                    // Remove the OrderHeader
                    _context.OrderHeader.Remove(orderHeader);

                    response.Message = "The Order Deleted";
                    response.Result = null;
                    response.IsSuccessful = true;

                    await _context.SaveChangesAsync();

                    scope.Complete();

                    return response;

                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }

        }

    }
}
