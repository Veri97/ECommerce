using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces;

namespace ECommerce.API.Application.Services;

public class BasketService : IBasketService
{
    private readonly IBasketRepository _basketRepository;
    public BasketService(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<CustomerBasket> GetBasketByIdAsync(string id)
    {
        var basket = await _basketRepository.GetBasketAsync(id);

        return basket ?? new CustomerBasket(id);
    }

    public async Task<CustomerBasket> AddOrUpdateBasketAsync(CustomerBasket basket)
    {
        var basketToCreateOrUpdate = await _basketRepository.AddOrUpdateBasketAsync(basket);

        return basketToCreateOrUpdate;
    }

    public async Task<bool> DeleteBasketAsync(string id)
    {
        var deleted = await _basketRepository.DeleteBasketAsync(id);

        return deleted;
    }
}
