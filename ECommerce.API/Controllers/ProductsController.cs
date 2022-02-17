using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;
public class ProductsController : BaseECommerceController
{
    [HttpGet]
    public string GetAllProducts()
    {
        return "This will be a list of products";
    }

    [HttpGet("{id}")]
    public string GetProduct(int id)
    {
        return $"single product - {id}";
    }
}

