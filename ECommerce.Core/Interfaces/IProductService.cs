using ECommerce.Core.Entities;

namespace ECommerce.Core.Interfaces;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
}
