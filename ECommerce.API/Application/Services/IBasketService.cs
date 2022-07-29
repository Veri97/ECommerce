using ECommerce.Core.Entities;

namespace ECommerce.API.Application.Services;

public interface IBasketService
{
    Task<CustomerBasket> GetBasketByIdAsync(string id);
    Task<CustomerBasket> AddOrUpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string id);
}
