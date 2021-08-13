using Application.Handlers.CustomerHandlers.Commands.AddCustomer;
using Application.Handlers.CustomerHandlers.Commands.DeleteCustomer;
using Application.Handlers.CustomerHandlers.Commands.UpdateCustomer;
using Application.Models.Customers;
using Application.Services.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    //********************************************************************************************************/
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<AddCustomerResponse>> PostAsync([FromBody] AddCustomerRequest payload)
        {
            var response = await _mediator.Send(payload);

            return CreatedAtRoute(
                routeValues: new { id = response.Id },
                value: response);
        }


        [HttpDelete("{customerId:Guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid customerId)
        {
            var payload = new DeleteCustomerRequest { Id = customerId };

            await _mediator.Send(payload);

            return Ok();
        }

        [HttpPut("{customerId:Guid}")]
        public async Task<ActionResult<UpdateCustomerResponse>> PutAsync(
            [FromRoute] Guid customerId,
            [FromBody] UpdateCustomerRequest payload)
        {
            payload.Id = customerId;

            var response = await _mediator.Send(payload);


            return Ok(response);
        }

        //****************************************************************************************************//

        //private readonly ICustomerService _customerService;

        //public CustomersController(ICustomerService customerService)
        //{
        //    _customerService = customerService;
        //}

        /// <summary>
        /// Add an Order
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult<CustomerModel>> PostAsync([FromBody] AddCustomerModel payload)
        //{
        //    var model = await _customerService.AddCustomerAsync(payload);

        //    return CreatedAtRoute(
        //        routeValues: new { id = model.Id },
        //        value: model);
        //}

        //[HttpGet("{customerId:Guid}")]
        //public async Task<ActionResult<CustomerModel>> GetAsync([FromRoute] Guid customerId)
        //{
        //    var model = await _customerService.GetCustomerAsync(customerId);

        //    return Ok(model);
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<CustomerModel>>> GetAsync()
        //{
        //    var models = await _customerService.GetCustomerListAsync();

        //    return Ok(models);
        //}

        //[HttpPut("{customerId:Guid}")]
        //public async Task<ActionResult<CustomerModel>> PutAsync(
        //    [FromRoute] Guid customerId,
        //    [FromBody] UpdateCustomerModel payload)
        //{
        //    payload.Id = customerId;

        //    var model = await _customerService.UpdateCustomerAsync(payload);

        //    return Ok(model);
        //}

        //[HttpDelete("{customerId:Guid}")]
        //public async Task<ActionResult> DeleteAsync([FromRoute] Guid customerId)
        //{
        //    var payload = new DeleteCustomerModel { Id = customerId };

        //    await _customerService.DeleteCustomerAsync(payload);

        //    return Ok();
        //}
    }
}
