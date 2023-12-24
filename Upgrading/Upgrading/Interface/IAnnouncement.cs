using System.Linq.Expressions;
using Upgrading.Models;

namespace Upgrading.Interface
{
    public interface IAnnouncement:IRepository<Announcement>
    {
        
        void Update(Announcement entity);
        
    }
}
