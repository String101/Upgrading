using Upgrading.Models;
using System.Linq.Expressions;

namespace Upgrading.Interface
{
    public interface ISubject:IRepository<Subjects>
    {
      
        void Update(Subjects entity);
        
    }
}
