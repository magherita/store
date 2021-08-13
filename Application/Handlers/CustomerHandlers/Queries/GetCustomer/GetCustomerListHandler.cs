using Database.Repositories.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CustomerHandlers.Queries.GetCustomer
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListRequest, List<GetCustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async  Task<List<GetCustomerResponse>> Handle(GetCustomerListRequest request, CancellationToken cancellationToken)
        {
            //// get customers from database
            var customers = await _customerRepository.RetrieveCustomersAsync(cancellationToken);

            //// map customer list to customer model list
            //var models = new List<CustomerModel>();

            //foreach (var customer in customers)
            //{
            //    var model = new CustomerModel
            //    {
            //        Id = customer.Id,
            //        Name = customer.Name,
            //        Address = customer.Address
            //    };

            //    models.Add(model);

            //    return models;
            //}


            return Task.FromResult(_customerRepository.RetrieveCustomerAsync());
        }
    }
}
