using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Upgrading.Repositories
{
    public class StudentRepo : Repository<Student>,IStudent
    {
        private readonly SQLiteDbContext _context;

        public StudentRepo(SQLiteDbContext context):base(context)
        {
            _context = context;
        }
  
        public void Update(Student entity)
        {
           _context.Students.Update(entity);
        }
    }
}
