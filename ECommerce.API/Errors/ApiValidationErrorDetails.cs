using ECommerce.API.Errors;

namespace FSHFNotification.API.Application.Errors;


public class ApiValidationErrorDetails : ApiResponse
{
    public ApiValidationErrorDetails() : base(400)
    {
    }
    public IEnumerable<string> Errors { get; set; }
}

