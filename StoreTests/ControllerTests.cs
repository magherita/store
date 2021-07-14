using API.Controllers;
using Database.Repositories.Customers;
using Domain.Customers;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StoreTests
{
    public class ControllerTests
    {
        [Fact]
        public void GetCorrect_No_Of_Customers()
        {
            //Arrange
            //int count = 5;
            //var fakeCustomers = A.CollectionOfDummy<Customer>(count).AsEnumerable();
            //var dataStore = A.Fake<CustomerRepository>();
            //A.CallTo(() => dataStore.RetrieveCustomerAsync(count)).Returns(Task.FromResult(fakeCustomers));
            //var controller = new CustomersController(dataStore);

            ////Act
            //var actionResult = await controller.GetCustomers(count);


            ////Assert
            //var result = actionResult.Result as OkObjectResult;
            //var returnCustomers = result.Value as IEnumerable<Customer>;
            //Assert.Equal(count, returnCustomers.Count());
        }
    }

}
