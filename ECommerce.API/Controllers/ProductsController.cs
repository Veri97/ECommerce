using ECommerce.Infrastructure.Data;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ECommerce.Core.Interfaces;

namespace ECommerce.API.Controllers;
public class ProductsController : BaseECommerceController
{
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await _productRepository.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok(await _productRepository.GetProductByIdAsync(id));
    }

    [HttpGet("brands")]
    public async Task<IActionResult> GetProductBrands()
    {
        return Ok(await _productRepository.GetProductBrandsAsync());
    }

    [HttpGet("types")]
    public async Task<IActionResult> GetProductTypes()
    {
        return Ok(await _productRepository.GetProductTypesAsync());
    }
}

