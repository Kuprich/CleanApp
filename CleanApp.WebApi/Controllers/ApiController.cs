using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CleanApp.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {

        Error firstError = errors[0];

        int statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };


        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
