﻿using MediatR;

namespace Application.Handlers.CustomerHandlers.Commands.AddCustomer
{
    public class AddCustomerRequest : IRequest<AddCustomerResponse>
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}