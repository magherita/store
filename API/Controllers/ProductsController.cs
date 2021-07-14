using Application.Models.Products;
using Application.Services.Products;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostAsync([FromBody] AddProductModel payload)
        {
            var model = await _productService.AddProductAsync(payload);

            return CreatedAtRoute(
                routeValues: new { id = model.Id },
                value: model);
        }

        [HttpGet("{productId:Guid}")]
        public async Task<ActionResult<ProductModel>> GetAsync([FromRoute] Guid productId)
        {
            var model = await _productService.GetProductAsync(productId);

            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAsync()
        {
            var models = await _productService.GetAllProductsAsync();

            return Ok(models);
        }

        [HttpPut("{productId:Guid}")]
        public async Task<ActionResult<ProductModel>> PutAsync(
            [FromRoute] Guid productId,
            [FromBody] UpdateProductModel payload)
        {
            payload.Id = productId;

            var model = await _productService.UpdateProductAsync(payload);

            return Ok(model);
        }

        [HttpDelete("{productId:Guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid productId)
        {
            var payload = new DeleteProductModel { Id = productId };

            await _productService.DeleteProductAsync(payload);

            return Ok();
        }
    }
}
