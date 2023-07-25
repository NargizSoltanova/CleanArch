using Microsoft.AspNetCore.Mvc;
using practice.Application.Handlers.Products.Commands;
using practice.Application.Handlers.Products.Queries;
using practice.WebApi.Controllers.Base;

namespace practice.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand createProductCommand)
        {
            return GetResponseOnlyResultData(await Mediator.Send(createProductCommand));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteProductCommand deleteProductCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteProductCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand updateProductCommand)
        {
            return GetResponseOnlyResultData(await Mediator.Send(updateProductCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetProductsQuery()));
        }
    }
}
