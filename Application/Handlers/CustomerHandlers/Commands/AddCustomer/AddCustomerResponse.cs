using System;

namespace Application.Handlers.CustomerHandlers.Commands.AddCustomer
{
    public class AddCustomerResponse
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
