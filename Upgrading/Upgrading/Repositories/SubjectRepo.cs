using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Upgrading.Repositories
{
    public class SubjectRepo : Repository<Subjects>,ISubject
    {
        public readonly SQLiteDbContext _context;

        public SubjectRepo(SQLiteDbContext context):base(context)
        {
            _context = context;
        }

        public void Update(Subjects entity)
        {
            _context.Subjects.Update(entity);
        }
    }
}
