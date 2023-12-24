using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Upgrading.Models;

namespace Upgrading.Data
{
    public class SQLiteDbContext : IdentityDbContext<ApplicationUser>
    {
        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
        {

        }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }  
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
