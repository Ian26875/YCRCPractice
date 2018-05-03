using System.Collections.Generic;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.Service.Interface
{
    /// <summary>
    /// Interface IOrderService
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        void CreateOrder(OrderDto orderDto);

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        void DeleteOrder(int orderId);

        /// <summary>
        /// Edits the order.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        void EditOrder(OrderDto orderDto);

        /// <summary>
        /// Gets the page all orders.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IList&lt;OrderDto&gt;.</returns>
        IList<OrderDto> GetPageAllOrders(int pageNumber, int pageSize);

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>OrderDto.</returns>
        OrderDto GetOrder(int orderId);
    }
}