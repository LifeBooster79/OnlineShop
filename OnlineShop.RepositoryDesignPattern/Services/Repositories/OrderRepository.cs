using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Dtos;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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

                }

                return response;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<IResponse<IEnumerable<OrderHeaderDetailDto>>> SelectOrder(string id)
        {
            var response= new Response<IEnumerable<OrderHeaderDetailDto>>();

            try
            {
                var enitites=await _context.OrderHeader.Where(o => o.SellerId == id || o.BuyerId==id).Select(s => new OrderHeaderDetailDto()
                {
                    orderHeader=s,
                    orderDetails=_context.OrderDetail.Where(o=>o.orderHeaderId==s.Id).ToList(),
                }).ToListAsync();

                if (enitites == null)
                {
                    response.Message = "Cant Find The Order";
                    response.IsSuccessful = false;
                }
                else
                {
                    response.Result = enitites;
                    response.Message = null;
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        //public virtual async Task<IResponse<IEnumerable<OrderHeader>>> SelectOrder(string searchId, int pageSize, int pageIndex)
        //{
        //    var response = new Response<IEnumerable<OrderHeader>>();


        //    var orderHeader = _context.OrderHeader.Select(o => o);
        //    if (searchId != null)
        //    {

        //        orderHeader = orderHeader.Where(o => o.SellerId == searchId || o.BuyerId == searchId);
        //    }
        //    orderHeader = orderHeader.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        //    if (orderHeader == null)
        //    {

        //        response.Message = "Cant Find The Order";
        //        response.Result = null;
        //        response.IsSuccessful = false;
        //    }
        //    else
        //    {
        //        response.Message =null;
        //        response.Result = await orderHeader.ToListAsync();
        //        response.IsSuccessful = true;
        //    }

        //    return response;
        //}

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
                    //Convert to PersianTime
                    //-----------------------------------------------------
                    PersianCalendar persianCalendar = new PersianCalendar();
                    DateTime dateTime = DateTime.Now;

                    int year = persianCalendar.GetYear(dateTime);
                    int month = persianCalendar.GetMonth(dateTime);
                    int day = persianCalendar.GetDayOfMonth(dateTime);

                    string persianDateTimeString = $"{year}/{month}/{day}";
                    //-----------------------------------------------------

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
                    entity.isModified = true;
                    entity.ModifyDatePersian = persianDateTimeString;
                    _context.OrderDetail.Update(entity);
                    response.Message = "The Order Updated";
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
            try
            {
                var response = new Response<String>();



                var orderHeader = await _context.OrderHeader.FindAsync(orderHeaderId);

                var orderDetails = _context.OrderDetail.Where(o => o.orderHeaderId == orderHeaderId);

                if (orderHeader == null)
                {
                    response.Message = "Cant Find The Order";
                    response.IsSuccessful = false;
                }
                else
                {
                    //Convert to PersianTime
                    //-----------------------------------------------------
                    PersianCalendar persianCalendar = new PersianCalendar();
                    DateTime dateTime = DateTime.Now;

                    int year = persianCalendar.GetYear(dateTime);
                    int month = persianCalendar.GetMonth(dateTime);
                    int day = persianCalendar.GetDayOfMonth(dateTime);

                    string persianDateTimeString = $"{year}/{month}/{day}";
                    //-----------------------------------------------------

                    orderHeader.IsSoftDeleted = true;

                    orderHeader.SoftDeleteDatePersian = persianDateTimeString;

                    List<OrderDetail> removedOrderDetails=new List<OrderDetail>();

                    foreach (var orderDetail in orderDetails)
                    {
                        orderDetail.IsSoftDeleted = true;
                        orderDetail.SoftDeleteDatePersian= persianDateTimeString;   
                        removedOrderDetails.Append(orderDetail);
                    }

                    // Remove all related OrderDetails
                    _context.OrderDetail.UpdateRange(removedOrderDetails);

                    // Remove the OrderHeader
                    _context.OrderHeader.Update(orderHeader);

                    response.Message = "The Order Deleted";
                    response.Result = null;
                    response.IsSuccessful = true;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public virtual async Task SavaeChanges()
        {
            await _context.SaveChangesAsync();
        }

    }

}
