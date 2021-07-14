using Database.Configurations;
using Domain.Customers;
using System;
using System.Diagnostics;
using Xunit;

namespace StoreTests
{
    public class DataBaseTests
    {
        [Fact]
        public void CanInsertCustomerIntoDatabase()
        {
            //using (var context = new StoreContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //    var customer = new Customer();
            //    context.Customers.Add(customer);
            //    Debug.WriteLine($"Before save: {customer.Id}");

            //    context.SaveChanges();
            //    Debug.WriteLine($"After save: {customer.Id}");

            //    Assert.NotEqual(0, customer.Id);
            //}
        }
    }
}
