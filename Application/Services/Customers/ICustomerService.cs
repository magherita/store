using Application.Models.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<CustomerModel> AddCustomerAsync(
            AddCustomerModel model,
            CancellationToken cancellationToken = default);

        Task<CustomerModel> UpdateCustomerAsync(
            UpdateCustomerModel model,
            CancellationToken cancellationToken = default);

        Task DeleteCustomerAsync(
            DeleteCustomerModel model,  
            CancellationToken cancellationToken = default);

        Task<CustomerModel> GetCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default);

        Task<List<CustomerModel>> GetCustomerListAsync(CancellationToken cancellationToken = default);
    }
}
