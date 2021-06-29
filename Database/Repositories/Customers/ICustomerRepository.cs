using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);

        Task<Customer> RetrieveCustomerAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Customer>> RetrieveCustomersAsync(CancellationToken cancellationToken = default);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
    }
}
