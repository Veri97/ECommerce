using ECommerce.API.Exceptions;
using FSHFNotification.API.Application.Errors;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECommerce.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _logger = logger;
            _next = next;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = ex switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = _env.IsDevelopment()
                   ? new ApiExceptionDetails(httpContext.Response.StatusCode, ex.Message, GetStackTrace(httpContext,ex))
                   : new ApiExceptionDetails(httpContext.Response.StatusCode, ex.Message);

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            await httpContext.Response.WriteAsync(json);
        }

        private static string GetStackTrace(HttpContext httpContext, Exception ex)
        {
            return httpContext.Response.StatusCode == StatusCodes.Status500InternalServerError ? ex.StackTrace.ToString() : null;
        }
    }
}
