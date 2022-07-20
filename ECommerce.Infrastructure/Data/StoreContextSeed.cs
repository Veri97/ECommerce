using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace ECommerce.Infrastructure.Data
{
    public class StoreContextSeed
    {
        private static async Task SaveDataAsync<T>(string filePath, StoreContext context)
            where T : BaseEntity
        {
            var jsonData = await File.ReadAllTextAsync(filePath);
            var data = JsonSerializer.Deserialize<List<T>>(jsonData);

            await context.Set<T>().AddRangeAsync(data);

            await context.SaveChangesAsync();
        }

        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (!(await context.ProductBrands.AnyAsync()))
                    await SaveDataAsync<ProductBrand>("../ECommerce.Infrastructure/Data/SeedData/brands.json",context);

                if (!(await context.ProductTypes.AnyAsync()))
                    await SaveDataAsync<ProductType>("../ECommerce.Infrastructure/Data/SeedData/types.json", context);

                if (!(await context.Products.AnyAsync()))
                    await SaveDataAsync<Product>("../ECommerce.Infrastructure/Data/SeedData/products.json", context);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
