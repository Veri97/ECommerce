using ECommerce.API.Errors;
using System.Net;

namespace FSHFNotification.API.Application.Errors;

public class ApiValidationErrorDetails : ApiResponse
{
    public ApiValidationErrorDetails() : base((int)HttpStatusCode.BadRequest) { }
    public IEnumerable<string> Errors { get; set; }
}