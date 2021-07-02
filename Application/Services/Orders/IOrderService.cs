using Application.Models.Orders;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderModel> AddOrderAsync(AddOrderModel model, CancellationToken cancellationToken = default);

        Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken cancellationToken = default);

        Task DeleteModelAsync(DeleteOrderModel model, CancellationToken cancellationToken = default);

        Task<OrderModel> GetOrderModelAsync(Guid orderId, CancellationToken cancellationToken = default);

        Task<List<OrderModel>> GetOrderModelListAsync(CancellationToken cancellationToken = default);
       
    }
}
