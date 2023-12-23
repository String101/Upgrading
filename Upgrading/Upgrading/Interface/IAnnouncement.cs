using System.Linq.Expressions;
using Upgrading.Models;

namespace Upgrading.Interface
{
    public interface IAnnouncement
    {
        IEnumerable<Announcement> GetAll(Expression<Func<Announcement, bool>>? filter = null, string? includeProperties = null);
        Announcement Get(Expression<Func<Announcement, bool>>? filter, string? includeProperties = null);
        void Add(Announcement entity);
        bool Any(Expression<Func<Announcement, bool>>? filter);
        void Remove(Announcement entity);
        void Update(Announcement entity);
        void Save();
    }
}
