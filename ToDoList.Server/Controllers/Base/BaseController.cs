using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using ToDiList.Domain.ResultModel;

namespace ToDoList.EndPoint.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        protected ActionResult ResultHandler<T>(Result<T> result)
        {
            //How Fail Should be
            if (result.IsSucces == false && !String.IsNullOrEmpty(result.ErrorMessage))
                return Ok(result);

            //How Success should be
            if(result.IsSucces && result.Data != null)
                return Ok(result);

            return BadRequest();
        }
    }
}
