using Application.Models.LineItems;
using Application.Services.LineItems;
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
    public class LineItemsController : ControllerBase
    {
        private readonly ILineItemService _lineItemService;

        public LineItemsController(ILineItemService lineItemService)
        {
            _lineItemService = lineItemService;
        }

        [HttpPost]
        public async Task<ActionResult<LineItemModel>> PostAsync([FromBody] AddLineItemModel paylaod)
        {
            var model = await _lineItemService.AddLineItemAsync(paylaod);

            return CreatedAtRoute(
                routeValues: new { id = model.Id },
                value: model);
        }

        [HttpGet]
        public async Task<ActionResult<List<LineItemModel>>> GetAsync()
        {
            var models = await _lineItemService.GetLineItemListAsync();

            return Ok(models);
        }

        [HttpGet("{lineItemId:Guid}")]
        public async Task<ActionResult<LineItemModel>> GetAsync([FromRoute] Guid lineItemId)
        {
            var model = await _lineItemService.GetLineItemAsync(lineItemId);

            return Ok(model);
        }

        [HttpPut("{lineItemId:Guid}")]
        public async Task<ActionResult<LineItemModel>> PutAsync([FromRoute] Guid lineItemId, [FromBody] UpdateLineItemModel payload)
        {
            payload.Id = lineItemId;

            var model = await _lineItemService.UpdateLineItemAsync(payload);

            return Ok(model);
        }

        [HttpDelete("{lineItemId:Guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid lineItemId)
        {
            var payload = new DeleteLineItemModel { Id = lineItemId };

            await _lineItemService.DeleteLineItemAsync(payload);

            return Ok();
        }


    }
}
