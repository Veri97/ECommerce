using System.Linq.Expressions;

namespace ECommerce.Core.Specifications;

public interface ISpecification<T>
{
    public Expression<Func<T,bool>> Criteria { get; }
    public List<Expression<Func<T,object>>> Includes { get; }
    public Expression<Func<T, object>> OrderBy { get; }
    public Expression<Func<T, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}
