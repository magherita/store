using Database.Repositories.Customers;
using Domain.Customers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CustomerHandlers.Commands.AddCustomer
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly ICustomerRepository _customerRespository;

        public AddCustomerHandler(ICustomerRepository customerRespository)
        {
            _customerRespository = customerRespository;
        }

        public async  Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
           //ensure the model is not null
            if (request == null)
            {
                throw new Exception("No customer details were provided!");
            }

            //map model to the customer domain  b
            var customer = new Customer
            {
                Name = request.Name,
                Address = request.Address
            };

            // create and save customer
            await _customerRespository.CreateCustomerAsync(customer, cancellationToken);

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
