using MediatR;
using System;

namespace Application.Handlers.CustomerHandlers.Commands.UpdateCustomer
{
    public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
