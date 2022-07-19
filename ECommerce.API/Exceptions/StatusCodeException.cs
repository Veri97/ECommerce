using System.Net;

namespace ECommerce.API.Exceptions
{
    public class StatusCodeException : ApplicationException, IStatusCodeException
    {
        public HttpStatusCode StatusCode { get; }

        HttpStatusCode IStatusCodeException.StatusCode => throw new NotImplementedException();

        public StatusCodeException(HttpStatusCode statusCode, string message) 
            : base(message) => StatusCode = statusCode;

        public StatusCodeException(HttpStatusCode statusCode, string message, Exception innerException)
            : base(message, innerException) => StatusCode = statusCode;
    }
}
