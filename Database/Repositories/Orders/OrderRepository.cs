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
        public async Task CreateOrderRepositoryAsync(Order order, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public async Task<Order> RetrieveCustomerOrderAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.Include(x => x.LineItems).Include(x => x.Customer).FirstOrDefaultAsync(x => x.CustomerId == customerId, cancellationToken);
        }

        public async Task<List<Order>> RetrieveOrdersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Orders.Include(x => x.LineItems ).ToListAsync(cancellationToken);
        }

        public async Task<Order> RetrieveSingleOrderAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.Include(x => x.LineItems).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
