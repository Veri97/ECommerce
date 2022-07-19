using System.Net;

namespace ECommerce.API.Exceptions;

public interface IStatusCodeException
{
    HttpStatusCode StatusCode { get; }
}
