using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.CustomerHandlers.Commands.DeleteCustomer
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}
