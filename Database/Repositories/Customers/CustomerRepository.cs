using Database.Configurations;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext _context;

        public CustomerRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAsync(
            Customer customer, 
            CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        public async Task<Customer> RetrieveCustomerAsync(
            Guid id, 
            CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Customer>> RetrieveCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);

            _context.SaveChanges();
        }
    }
}
