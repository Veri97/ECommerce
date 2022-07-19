using System.Net;

namespace ECommerce.API.Exceptions;

public class NotFoundException : StatusCodeException
{
    public NotFoundException(string msg) : base(HttpStatusCode.NotFound, msg) { }

    public NotFoundException(string msg, Exception ex) : base(HttpStatusCode.NotFound, msg, ex) { }
}
