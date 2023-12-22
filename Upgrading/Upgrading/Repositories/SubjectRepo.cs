using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Upgrading.Repositories
{
    public class SubjectRepo : ISubject
    {
        public readonly SQLiteDbContext _context;

        public SubjectRepo(SQLiteDbContext context)
        {
            _context = context;
        }
        public void Add(Subjects entity)
        {
            _context.Subjects.Add(entity);
        }

        public bool Any(Expression<Func<Subjects, bool>>? filter)
        {
           return _context.Subjects.Any(filter);
        }

        public Subjects Get(Expression<Func<Subjects, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<Subjects> query= _context.Subjects;
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

        public IEnumerable<Subjects> GetAll(Expression<Func<Subjects, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Subjects> query = _context.Subjects;
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
            return query.ToList();
        }

      

        public void Remove(Subjects entity)
        {
            _context.Subjects.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Subjects entity)
        {
            _context.Subjects.Update(entity);
        }
    }
}
