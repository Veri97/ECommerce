using System.Net;

namespace ECommerce.API.Exceptions;

public class UnauthorizedException : StatusCodeException
{
    public UnauthorizedException(string msg) : base(HttpStatusCode.Unauthorized, msg) { }

    public UnauthorizedException(string msg, Exception ex) : base(HttpStatusCode.Unauthorized, msg, ex) { }
}
