using Upgrading.Data;
using Upgrading.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Upgrading.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly SQLiteDbContext _context;
        internal DbSet<T> _dbSet;
        public Repository(SQLiteDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                  .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp.Trim());
                }

            }
            return query.FirstOrDefault();
        }
    }
}
