using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ECommerce.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (!(await context.ProductBrands.AnyAsync()))
                {
                    var brandsData = await File.ReadAllTextAsync("../ECommerce.Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    await context.ProductBrands.AddRangeAsync(brands);
                }

                if (!(await context.ProductTypes.AnyAsync()))
                {
                    var typesData = await File.ReadAllTextAsync("../ECommerce.Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    await context.ProductTypes.AddRangeAsync(types);
                }

                if (!(await context.Products.AnyAsync()))
                {
                    var brandsData = await File.ReadAllTextAsync("../ECommerce.Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(brandsData);

                    await context.Products.AddRangeAsync(products);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
