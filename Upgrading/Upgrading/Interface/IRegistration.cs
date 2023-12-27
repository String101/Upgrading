using Upgrading.Models;

namespace Upgrading.Interface
{
    public interface IRegistration: IRepository<Registration>
    {
         void Update(Registration entity);
    }
}
