using ECommerce.API.Application.Services;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

public class BasketController : BaseECommerceController
{
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBasketById(string id)
    {
        return Ok(await _basketService.GetBasketByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdateBasket(CustomerBasket basket)
    {
        return Ok(await _basketService.AddOrUpdateBasketAsync(basket));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket(string id)
    {
        await _basketService.DeleteBasketAsync(id);

        return NoContent();
    }
}
