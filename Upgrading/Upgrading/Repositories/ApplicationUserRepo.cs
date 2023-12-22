using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Upgrading.Interface;

using Upgrading.Data;
using Upgrading.Models;

namespace Upgrading.Repositories
{
    public class ApplicationUserRepo: Repository<ApplicationUser>,IApplicationUser
    {
        private readonly SQLiteDbContext _context;

        public ApplicationUserRepo(SQLiteDbContext context):base(context)
        {
            _context = context;
        }
        
    }
}
