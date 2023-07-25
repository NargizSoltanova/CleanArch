using MediatR;
using Microsoft.AspNetCore.Mvc;
using practice.Application.Common.Results;

namespace practice.WebApi.Controllers.Base
{
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [ApiExplorerSettings(IgnoreApi = true)]
        public static IActionResult GetResponseOnlyResultMessage(practice.Application.Common.Results.IResult result)
        {
            return result.Success ? new OkObjectResult(result.Message) : new BadRequestObjectResult(result.Message);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public static IActionResult GetResponseOnlyResultData<T>(IDataResult<T> result)
        {
            return result.Success ? new OkObjectResult(result.Data) : new BadRequestObjectResult(result.Message);
        }
    }
}
