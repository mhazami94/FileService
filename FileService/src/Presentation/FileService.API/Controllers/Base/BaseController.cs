using FileService.Application.Core.CQRS.CommandHandling;
using FileService.Application.Core.CQRS.QueryHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileService.API.Controllers.Base
{
    [ApiController]
    public class BaseController : Controller
    {
        public readonly IMediator Mediator;
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async new Task<IActionResult> Response<TResult>(Query<TResult> query)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var queryHandlerResult = await Mediator.Send(query);
                return queryHandlerResult.ValidationResult.IsValid ? OkActionResult(queryHandlerResult.Result)
                    : BadRequestActionResult(queryHandlerResult.ValidationResult.Errors);
            }
            catch (Exception e)
            {
                return BadRequestActionResult(e.Message);
            }
        }

        protected async new Task<IActionResult> Response<TResult>(Command<TResult> command) where TResult : struct
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var commandHandlerResult = await Mediator.Send(command);
                return commandHandlerResult.ValidationResult.IsValid ? OkActionResult(commandHandlerResult.Id)
                    : BadRequestActionResult(commandHandlerResult.ValidationResult.Errors);
            }
            catch (Exception ex)
            {
                return BadRequestActionResult(ex.Message);
            }
        }

        private IActionResult OkActionResult(dynamic result)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        private IActionResult BadRequestActionResult(dynamic resultError)
        {
            return BadRequest(new
            {
                success = false,
                message = resultError
            });
        }

    }
}
