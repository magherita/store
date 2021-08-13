using System;

namespace Application.Handlers.CustomerHandlers.Queries.GetCustomer
{
    public class GetCustomerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
