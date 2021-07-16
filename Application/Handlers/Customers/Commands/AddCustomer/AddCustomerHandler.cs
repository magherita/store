using Database.Repositories.Customers;
using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Customers.Commands.AddCustomer
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<AddCustomerResponse> Handle(
            AddCustomerRequest request, 
            CancellationToken cancellationToken)
        {
            // ensure the model is not null
            if (request == null)
            {
                throw new Exception("No customer details were provided!");
            }

            // map model to the customer domain
            var customer = new Customer
            {
                Name = request.Name,
                Address = request.Address
            };

            // create and save customer
            await _customerRepository.CreateCustomerAsync(customer, cancellationToken);

            // customer has been saved
            // map customer to customer model and return
            return new AddCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address
            };
        }
    }
}
