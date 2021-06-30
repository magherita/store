using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.Orders
{
    public interface IOrderRepository
    {
        // Define Product CRUD methods.
        Task CreateOrdersAsync(Order order, CancellationToken cancellationToken = default);

        Task<Order> RetrieveOrderAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Order>> RetrieveOrderAsync(CancellationToken cancellationToken = default);

        void UpdateOrder(Order order);

        void DeleteOrder(Order order);
    }
}
