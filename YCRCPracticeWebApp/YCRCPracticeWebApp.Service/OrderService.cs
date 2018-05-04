using AutoMapper;
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

        public IList<OrderDto> GetPageAllOrders(int pageNumber, int pageSize)
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
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToList();
            var dtos = Mapper.Map<IList<Orders>, IList<OrderDto>>(source);
            return dtos;
        }

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

        public void CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto));
            }
            var model = Mapper.Map<OrderDto, Orders>(orderDto);
            _orderRepo.Insert(model);
        }
    
        public void DeleteOrder(int orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }
            var order = _orderRepo.Find(orderId);
            _orderRepo.Delete(order);
        }

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
