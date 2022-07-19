using System.Net;

namespace ECommerce.API.Exceptions;

public class BadRequestException : StatusCodeException
{
    public BadRequestException(string msg) : base(HttpStatusCode.BadRequest, msg) { }

    public BadRequestException(string msg, Exception ex) : base(HttpStatusCode.BadRequest, msg, ex) { }
}
