using System.Linq.Expressions;

namespace Upgrading.Interface
{
    public interface IRepository<T> where T : class 
    {
        T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null);
    }
  
}
