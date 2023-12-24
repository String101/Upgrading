using Upgrading.Models;

namespace Upgrading.Interface
{
    public interface IProduct:IRepository<Products>
    {
        void Update(Products entity);
    }
}
