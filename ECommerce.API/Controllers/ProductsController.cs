using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Services;
using ECommerce.Core.Specifications;

namespace ECommerce.API.Controllers;
public class ProductsController : BaseECommerceController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecParams productParams)
    {
        return Ok(await _productService.GetAllProductsAsync(productParams));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok(await _productService.GetProductByIdAsync(id));
    }

    [HttpGet("brands")]
    public async Task<IActionResult> GetProductBrands()
    {
        return Ok(await _productService.GetAllProductBrandsAsync());
    }

    [HttpGet("types")]
    public async Task<IActionResult> GetProductTypes()
    {
        return Ok(await _productService.GetAllProductTypesAsync());
    }
}