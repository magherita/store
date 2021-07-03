using Application.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderModel> AddOrderAsync(
            AddOrderModel model, CancellationToken cancellationToken = default);
        Task<OrderModel> UpdateOrderAsync(
            UpdateOrderModel model,
            CancellationToken cancellationToken = default);

        Task DeleteOrderAsync(
            DeleteOrderModel model,
            CancellationToken cancellationToken = default);

        Task<OrderModel> GetOrderAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<List<OrderModel>> GetOrderListAsync(CancellationToken cancellationToken = default);
    }
}
