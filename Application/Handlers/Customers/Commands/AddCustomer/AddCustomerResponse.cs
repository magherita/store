using System;

namespace Application.Handlers.Customers.Commands.AddCustomer
{
    public class AddCustomerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
