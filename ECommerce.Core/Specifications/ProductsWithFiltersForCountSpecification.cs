using ECommerce.Core.Entities;

namespace ECommerce.Core.Specifications;

public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
{
    public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams)
        : base(criteria: x =>
             (string.IsNullOrEmpty(productParams.Name) || x.Name.ToLower().Contains(productParams.Name)) &&
             (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
             (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
          )
    { }
}
