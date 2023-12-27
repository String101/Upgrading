using Upgrading.Models;

namespace Upgrading.Interface
{
    public interface ITimetable:IRepository<TimeTable>
    {
        void Update(TimeTable entity);
    }
}
