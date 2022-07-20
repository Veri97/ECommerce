using ECommerce.API.Errors;

namespace FSHFNotification.API.Application.Errors;

public class ApiExceptionDetails : ApiResponse
{
    public ApiExceptionDetails(int statusCode, string message = null, string details = null)
        : base(statusCode,message)
    {
        Details = details;
    }

    public string Details { get; set; }
}