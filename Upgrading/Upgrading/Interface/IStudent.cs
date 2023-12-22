using Upgrading.Models;
using System.Linq.Expressions;

namespace Upgrading.Interface
{
    public interface IStudent
    {
        IEnumerable<Student> GetAll(Expression<Func<Student, bool>>? filter = null, string? includeProperties = null);
        Student Get(Expression<Func<Student, bool>>? filter, string? includeProperties = null);
        void Add(Student entity);
        bool Any(Expression<Func<Student, bool>>? filter);
        void Remove(Student entity);
        void Update(Student entity);
        void Save();
    }
}
