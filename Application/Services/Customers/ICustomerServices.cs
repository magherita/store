using Application.Models.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Customers
{
    public interface ICustomerServices
    {
        Task<CustomerModel> AddCustomerAsync(AddCustomerModel customer, CancellationToken cancellationToken = default);
        CustomerModel UpdateCustomer(UpdateCustomerModel customer);
        void DeleteCustomer(DeleteCustomerModel customer);

        Task<CustomerModel> GetCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);

        Task<list<CustomerModel>> GetCustomerListAsync(CancellationToken cancellationToken = default);
    }
}
