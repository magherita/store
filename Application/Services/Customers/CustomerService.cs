using Application.Models.Customers;
using AutoMapper;
using Database.Repositories.Customers;
using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerModel> AddCustomerAsync(
            AddCustomerModel model, 
            CancellationToken cancellationToken = default)
        {
            // ensure the model is not null
            //if (model == null)
            //{
            //    throw new Exception("No customer details were provided!");
            //}

            // map model to the customer domain
            //var customer = new Customer
            //{ 
            //    Name = model.Name,
            //    Address = model.Address
            //};

            //Another way of mapping
            var customer = _mapper.Map<Customer>(model);

     

            // create and save customer
            await _customerRepository.CreateCustomerAsync(customer, cancellationToken);

            // customer has been saved
            // map customer to customer model and return
            //return new CustomerModel
            //{ 
            //    Id = customer.Id,
            //    Name = customer.Name,
            //    Address = customer.Address
            //};

            var customerModel = _mapper.Map<CustomerModel>(customer);

            return customerModel;
        }

        public async Task DeleteCustomerAsync(
            DeleteCustomerModel model, 
            CancellationToken cancellationToken = default)
        {
            // ensure the model is not null
            if (model == null)
            {
                throw new Exception("No customer id was provided!");
            }

            // get customer using provided id
            var customer = await _customerRepository.RetrieveCustomerAsync(model.Id, cancellationToken);

            // ensure the customer is not null
            if (customer == null)
            {
                throw new Exception("No customer was found in the database!");
            }

            // delete the customer
            _customerRepository.DeleteCustomer(customer);
        }

        public async Task<CustomerModel> GetCustomerAsync(
            Guid customerId, 
            CancellationToken cancellationToken = default)
        {
            // get customer from database
            var customer = await _customerRepository.RetrieveCustomerAsync(customerId, cancellationToken);

            // ensure the customer is not null
            if (customer == null)
            {
                throw new Exception($"No customer was found in the database with id {customerId}!");
            }

            // map customer to the customer model
            //return new CustomerModel
            //{ 
            //    Id = customer.Id,
            //    Name = customer.Name,
            //    Address = customer.Address
            //};


            var customerModel = _mapper.Map<CustomerModel>(customer);
            return customerModel;
        }

        public async Task<List<CustomerModel>> GetCustomerListAsync(
            CancellationToken cancellationToken = default)
        {
            // get customers from database
            var customers = await _customerRepository.RetrieveCustomersAsync(cancellationToken);

            // map customer list to customer model list
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
            //}

            var models = _mapper.Map<List<CustomerModel>>(customers);

            return models;
        }

        public async Task<CustomerModel> UpdateCustomerAsync(
            UpdateCustomerModel model, 
            CancellationToken cancellationToken = default)
        {
            // verify the customer already exists in the database
            var customer = await _customerRepository.RetrieveCustomerAsync(model.Id, cancellationToken);

            // ensure the customer exists
            if (customer == null)
            {
                throw new Exception($"No customer was found in the database with id {model.Id}!");
            }

            // update exisiting customer details with new details from the model
            customer.Name = model.Name;
            customer.Address = model.Address;

            // update the customer in the database
            _customerRepository.UpdateCustomer(customer);

            //return new CustomerModel
            //{ 
            //    Id = customer.Id,
            //    Name = customer.Name,
            //    Address = customer.Address
            //};

            var customerModel = _mapper.Map<CustomerModel>(customer);
            return customerModel;
        }
    }
}
