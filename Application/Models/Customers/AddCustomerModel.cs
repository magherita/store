using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Customers
{
    public class AddCustomerModel
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }

    public class AddCustomerValidator : AbstractValidator<AddCustomerModel>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
