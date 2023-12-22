using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Upgrading.Repositories
{
    public class StudentRepo : IStudent
    {
        private readonly SQLiteDbContext _context;

        public StudentRepo(SQLiteDbContext context)
        {
            _context = context;
        }
        public void Add(Student entity)
        {
            _context.Students.Add(entity);
        }

        public bool Any(Expression<Func<Student, bool>>? filter)
        {
           return _context.Students.Any(filter);
        }

        public Student Get(Expression<Func<Student, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<Student> query = _context.Students;
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

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Student> query = _context.Students;
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

        public void Remove(Student entity)
        {
            _context.Students.Remove(entity);   
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public void Update(Student entity)
        {
           _context.Students.Update(entity);
        }
    }
}
