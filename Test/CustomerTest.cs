using Application.Models.Customers;
using Application.Services.Customers;
using System;
using System.Threading;
using Xunit;

namespace Test
{
    public class CustomerTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void IsAddCustomerModelEmpty()
        {
            AddCustomerModel expected = new AddCustomerModel { Name = "ignatius", Address = "kansanga" };

            AddCustomerModel model = new AddCustomerModel { Name = "", Address = "" };

            //AddCustomerModel actual = CustomerService.AddCustomerAsync(model);

            //Assert.NotEqual(expected, actual);
        }
        [Fact]
        public void IsDeleteCustomerModelEmpty()
        {
            //DeleteCustomerModel deleteModel = new DeleteCustomerModel { Id = 6c66a2c6-062a-4aa4-403f-08d93fb29219 };

            
        }


    }
}
