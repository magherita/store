using Application.Handlers.CustomerHandlers.Queries.GetCustomer;
using Application.Models.Customers;
using AutoMapper;
using Domain.Customers;

namespace Application.Mappers.Customers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<AddCustomerModel, Customer>(MemberList.Source);
            CreateMap<UpdateCustomerModel, Customer>(MemberList.Source);
            //CreateMap<Customer, CustomerModel>(MemberList.Destination);
            CreateMap<Customer, GetCustomerListRequest>(MemberList.Destination);
        }

    }
}
