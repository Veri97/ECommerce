
using ECommerce.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("errors/{code}")]
public class ErrorController : BaseECommerceController
{
    [HttpGet]
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code, "Resource not found!"));
    }
}
