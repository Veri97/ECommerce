using ECommerce.API.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.API.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseECommerceController
{
    public IActionResult Error(int code)
    {
        if (code == (int)HttpStatusCode.Unauthorized)
            return new UnauthorizedObjectResult(new ApiResponse(401, "Oops! Not authorized!"));

        return new ObjectResult(new ApiResponse(code, "Oops! Requested resource not found!"));
    }
}
