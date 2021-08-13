using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.CustomerHandlers.Queries.GetCustomer
{

    public class GetCustomerListRequest : IRequest<List<GetCustomerResponse>>
    {

    }
}
