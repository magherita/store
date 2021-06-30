using Database.Configurations;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _context;

        public OrderRepository(StoreContext context)
        {
            _context = context;
        }

        public StoreContext Context { get; }

        public async Task CreateOrdersAsync(Order order, CancellationToken cancellationToken = default)
        {
           await _context.Orders.AddAsync(new Order { });

           await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);

            _context.SaveChanges();
        }

        public async Task<Order> RetrieveOrderAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Order>> RetrieveOrderAsync(CancellationToken cancellationToken = default)
        {
           return await _context.Orders.ToListAsync(cancellationToken);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);

            _context.SaveChanges();
        }
    }
}
