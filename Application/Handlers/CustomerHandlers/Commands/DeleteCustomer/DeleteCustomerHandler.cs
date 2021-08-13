using Database.Repositories.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CustomerHandlers.Commands.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        private readonly ICustomerRepository _customerRespository;

        public DeleteCustomerHandler(ICustomerRepository customerRespository)
        {
            _customerRespository = customerRespository;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            // ensure the model is not null
            if (request == null)
            {
                throw new Exception("No customer id was provided!");
            }

            // get customer using provided id
            var customer =await _customerRespository.RetrieveCustomerAsync(request.Id, cancellationToken);

            // ensure the customer is not null
            if (customer == null)
            {
                throw new Exception("No customer was found in the database!");
            }

            // delete the customer
            _customerRespository.DeleteCustomer(customer);

            return new DeleteCustomerResponse
            {

                
            
            };

        }
    }
}
