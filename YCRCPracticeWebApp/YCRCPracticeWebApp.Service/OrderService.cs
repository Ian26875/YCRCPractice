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

        /// <summary>
        /// Gets the page all orders.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IList&lt;OrderDto&gt;.</returns>
        public IList<OrderDto> GetPageAllOrders(int pageNumber, int pageSize)
        {
            var source = _orderRepo
                .GetAll()
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();
            var dtos = Mapper.Map<IList<Orders>, IList<OrderDto>>(source);
            return dtos;
        }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        public void CreateOrder(OrderDto orderDto)
        {
            var model = Mapper.Map<OrderDto, Orders>(orderDto);
            _orderRepo.Insert(model);
        }

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public void DeleteOrder(int orderId)
        {
            var order=_orderRepo.Find(orderId);
            _orderRepo.Delete(order);
        }

        /// <summary>
        /// Edits the order.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        public void EditOrder(OrderDto orderDto)
        {
            var model = Mapper.Map<OrderDto, Orders>(orderDto);
            _orderRepo.Update(model);
        }
    }
}
