using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Repositories
{
    public class RegistrationRepo : Repository<Registration>, IRegistration
    {
        private readonly SQLiteDbContext _context;
        public RegistrationRepo(SQLiteDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Registration entity)
        {
            _context.Registrations.Update(entity);
        }
    }
}
