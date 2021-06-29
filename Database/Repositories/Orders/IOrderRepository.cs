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
        Task CreateOrderRepositoryAsync(Order order, CancellationToken cancellationToken = default);
        Task<Order> RetrieveSingleOrderAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<List<Order>> RetrieveOrdersAsync(CancellationToken cancellationToken = default);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
