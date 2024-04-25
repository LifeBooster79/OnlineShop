using OnlineShop.Application.Contracts;
using OnlineShop.Application.Dtos.OrderDto;
using OnlineShop.Application.Dtos.ProductCategoryDto;
using OnlineShop.Application.Dtos.ProductDto;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.SaleService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository)
        {

            _orderRepository = orderRepository;
        }


        public async Task<IResponse<string>> InsertAsync(ServiceCreateOrderDto createDto, string seller, string buyer)
        {

            var orderHeader = new OrderHeader()
            {
                Id=Guid.NewGuid(),
                SellerId = seller,
                BuyerId=buyer,

            };

            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (ServiceOrderDetailsDto orderDetailDto in createDto.OrderDetails)
            {
                orderDetails.Add(new OrderDetail()
                {
                    orderHeaderId = orderHeader.Id,
                    productId = orderDetailDto.productId,
                    UnitPrice = orderDetailDto.UnitPrice,
                    Quantity = orderDetailDto.Quantity,
                });
            }

            var result = await _orderRepository.Insert(orderHeader, orderDetails);

            return result;
        }

        public async Task<IResponse<IEnumerable<OrderHeader>>> SelectOrderAsync(string searchString, int pageSize, int pageIndex)
        {
            var result = await _orderRepository.SelectOrder(searchString, pageSize, pageIndex);

            return result;
        }
        public async Task<IResponse<IEnumerable<OrderDetail>>> SelectOrderDetialsASync(Guid searchString, int pageSize, int pageIndex)
        {
            var result = await _orderRepository.SelectOrderDetail(searchString, pageSize, pageIndex);

            return result;
        }
        public async Task UpdateAsync(ServiceUpdateOrderDto updateDto)
        {
            var orderDetial = new OrderDetail()
            {
                orderHeaderId = updateDto.orderHeaderId,
                productId = updateDto.productId,
                UnitPrice = updateDto.UnitPrice,
                Quantity = updateDto.Quantity,
            };

            await _orderRepository.Update(orderDetial, updateDto.orderHeaderId, updateDto.productId);
        }
        public async Task<IResponse<string>> DeleteAsync(ServiceDeleteOrderDto deleteOrderDto)
        {
            var result = await _orderRepository.Delete(deleteOrderDto.orderHeaderId);

            return result;
        }

    }
}
