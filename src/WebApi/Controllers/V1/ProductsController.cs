using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practice.Application.Common.Interfaces;
using practice.Application.Handlers.Products.Commands;
using practice.Application.Handlers.Products.Queries;
using practice.WebApi.Controllers.Base;

namespace practice.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand createProductCommand)
        {
            //Product product = _mapper.Map<Product>(createProductCommand);
            //await _context.Products.AddAsync(product);
            //await _context.SaveChangesAsync(cancellationToken);
            //return Ok();
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
