using Upgrading.Data;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Repositories
{
    public class ProductRepo:Repository<Products>,IProduct
    {
        private readonly SQLiteDbContext _context;

        public ProductRepo(SQLiteDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Products entity)
        {
            _context.Products.Update(entity);
        }
    }
}
