using Application.Models.Orders;
using Application.Services.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Get The Single order
        [HttpGet("{orderId:Guid}")]
        public async Task<ActionResult<OrderModel>> GetAsync([FromRoute] Guid orderId)
        {
            var model = await _orderService.GetOrderAsync(orderId);

            return Ok(model);
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetAsync()
        {
            var models = await _orderService.GetOrderModelListAsync();

            return Ok(models);
        }
        

        // Add an order
        [HttpPost]
        public async Task<ActionResult<OrderModel>> AddOrderAsync([FromBody] AddOrderModel payload)
        {
            var model = await _orderService.AddOrderAsync(payload);

            //Get 

            return CreatedAtRoute(
                routeValues: new { id = model.Id},
                value: model);
        }

        [HttpPut("{orderId:Guid}")]
        public async Task<ActionResult<OrderModel>> PutAsync([FromRoute] Guid orderId, [FromBody] UpdateOrderModel payload)
        {
            payload.Id = orderId;

            var model = await _orderService.UpdateOrderAsync(payload);

            return Ok(model);
        }

        [HttpDelete("{orderId:Guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid orderId) 
        {
            var payload = new DeleteOrderModel { Id = orderId };

            await _orderService.DeleteModelAsync(payload);

            return Ok();
        }

    }
}
