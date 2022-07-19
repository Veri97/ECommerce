using System.Net;

namespace ECommerce.API.Exceptions;

public class InternalServerErrorException : StatusCodeException
{
    public InternalServerErrorException(string msg) : base(HttpStatusCode.InternalServerError, msg) { }

    public InternalServerErrorException(string msg, Exception ex) : base(HttpStatusCode.InternalServerError, msg, ex) { }
}
