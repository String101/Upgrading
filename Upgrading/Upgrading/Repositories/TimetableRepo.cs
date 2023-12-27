using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Repositories
{
    public class TimetableRepo : Repository<TimeTable>, ITimetable
    {
        private readonly SQLiteDbContext _context;
        public TimetableRepo(SQLiteDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(TimeTable entity)
        {
            _context.TimeTables.Update(entity);
        }
    }
}
