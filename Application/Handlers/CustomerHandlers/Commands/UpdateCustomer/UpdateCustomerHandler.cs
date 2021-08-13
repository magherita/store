using Database.Repositories.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CustomerHandlers.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRespository;

        public UpdateCustomerHandler(ICustomerRepository customerRespository)
        {
            _customerRespository = customerRespository;
        }

        public async  Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            // verify the customer already exists in the database
            var customer = await _customerRespository.RetrieveCustomerAsync(request.Id, cancellationToken);

            // ensure the customer exists
            if (customer == null)
            {
                throw new Exception($"No customer was found in the database with id {request.Id}!");
            }

            // update exisiting customer details with new details from the request
            customer.Name = request.Name;
            customer.Address = request.Address;

            // update the customer in the database
            _customerRespository.UpdateCustomer(customer);

            return new UpdateCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address
            };

            //var customerModel = _mapper.Map<CustomerModel>(customer);
            //return customerModel;
        }
    }
}
