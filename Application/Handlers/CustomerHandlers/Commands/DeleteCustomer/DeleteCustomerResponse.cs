using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.CustomerHandlers.Commands.DeleteCustomer
{
    public class DeleteCustomerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
