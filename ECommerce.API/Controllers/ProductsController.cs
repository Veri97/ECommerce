using ECommerce.Infrastructure.Data;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers;
public class ProductsController : BaseECommerceController
{
    private readonly StoreContext _context;
    public ProductsController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok(await _context.Products.FindAsync(id));
    }
}

