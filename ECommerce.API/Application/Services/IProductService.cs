using ECommerce.API.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.Application.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductToReturnDTO>> GetAllProductsAsync();
    Task<ProductToReturnDTO> GetProductByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
}
