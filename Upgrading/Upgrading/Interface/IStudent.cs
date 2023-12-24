using Upgrading.Models;
using System.Linq.Expressions;

namespace Upgrading.Interface
{
    public interface IStudent:IRepository<Student>
    {
       
        void Update(Student entity);
        
    }
}
