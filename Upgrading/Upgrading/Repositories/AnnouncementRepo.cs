using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Repositories
{
    public class AnnouncementRepo:IAnnouncement
    {
        private readonly SQLiteDbContext _context;

        public AnnouncementRepo(SQLiteDbContext context)
        {
            _context = context;
        }

        public void Add(Announcement entity)
        {
            _context.Announcements.Add(entity);
        }

        public bool Any(Expression<Func<Announcement, bool>>? filter)
        {
          return  _context.Announcements.Any(filter);
        }

        public Announcement Get(Expression<Func<Announcement, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<Announcement> query = _context.Announcements;
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

        public IEnumerable<Announcement> GetAll(Expression<Func<Announcement, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Announcement> query = _context.Announcements;
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

        public void Remove(Announcement entity)
        {
            _context.Announcements.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Announcement entity)
        {
            _context.Announcements.Update(entity);
        }
    }
}
