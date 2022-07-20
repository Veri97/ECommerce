using ECommerce.Core.Entities;
using ECommerce.Core.Specifications;

namespace ECommerce.Core.Interfaces;

public interface IGenericRepository<T>
    where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAllWithSpecAsync(ISpecification<T> spec);
}
