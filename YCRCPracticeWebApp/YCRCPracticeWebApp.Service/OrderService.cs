﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCRCPracticeWebApp.Repository;
using YCRCPracticeWebApp.Repository.Interface;
using YCRCPracticeWebApp.Service.DataTransferObject;
using YCRCPracticeWebApp.Service.Interface;

namespace YCRCPracticeWebApp.Service
{
    /// <summary>
    /// Class OrderService.
    /// </summary>
    public class OrderService : IOrderService
    {

        /// <summary>
        /// The order repo
        /// </summary>
        private readonly IGeneralRepository<Orders> _orderRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepo">The order repo.</param>
        public OrderService(IGeneralRepository<Orders> orderRepo)
        {
            this._orderRepo = orderRepo;
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>System.Collections.Generic.IList&lt;YCRCPracticeWebApp.Service.DataTransferObject.OrderDto&gt;.</returns>
        public IList<OrderDto> GetAllOrders()
        {

            var source = _orderRepo.GetAll()
                                   .ToList();
            var dtos = Mapper.Map<IList<Orders>, IList<OrderDto>>(source);
            return dtos;
        }

        /// <summary>
        /// Gets the page all orders.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IList&lt;OrderDto&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// pageNumber
        /// or
        /// pageSize
        /// </exception>
        public IList<OrderDto> GetPageOrders(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            var source = _orderRepo
                    .GetAll()
                    .OrderBy(x=>x.OrderID)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            var dtos = Mapper.Map<IList<Orders>, IList<OrderDto>>(source);
            return dtos;
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>OrderDto.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">orderId</exception>
        public OrderDto GetOrder(int orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }
            var source = _orderRepo.Find(orderId);
            var dto = Mapper.Map<Orders, OrderDto>(source);
            return dto;
        }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        /// <exception cref="System.ArgumentNullException">orderDto</exception>
        public void CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto));
            }
            var model = Mapper.Map<OrderDto, Orders>(orderDto);
            _orderRepo.Insert(model);
        }

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">orderId</exception>
        public void DeleteOrder(int orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }
            var order = _orderRepo.Find(orderId);
            _orderRepo.Delete(order);
        }

        /// <summary>
        /// Edits the order.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        /// <exception cref="System.ArgumentNullException">orderDto</exception>
        public void EditOrder(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto));
            }
            var model = Mapper.Map<OrderDto, Orders>(orderDto);
            _orderRepo.Update(model);
        }

    }
}
