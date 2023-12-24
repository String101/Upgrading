using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Repositories
{
    public class AnnouncementRepo:Repository<Announcement>,IAnnouncement
    {
        private readonly SQLiteDbContext _context;

        public AnnouncementRepo(SQLiteDbContext context):base(context)
        {
            _context = context;
        }
        public void Update(Announcement entity)
        {
            _context.Announcements.Update(entity);
        }
    }
}
