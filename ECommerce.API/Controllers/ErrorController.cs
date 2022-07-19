
using ECommerce.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;


[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseECommerceController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code, "Oops! Requested resource not found!"));
    }
}
