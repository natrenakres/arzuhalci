using ArzuhalCI.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace ArzuhalCI.Web.Api.Controllers;

[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleApplicationError(Error error)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request.",
            Detail = error.Description,
            Status = error.StatusCode ?? StatusCodes.Status400BadRequest, 
            Instance = HttpContext.Request.Path,
            Extensions =
            {
                ["errorCode"] = error.Code 
            },
            Type = error.Type.ToString()
        };

        return new ObjectResult(problemDetails) { StatusCode = problemDetails.Status };
    }
}