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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Student>().HasData(
                
            //    new Student
            //    {
            //        StudentId=1,
            //        StudentName="Sbongakonke",
            //        Subjects = [
            //         new Subjects
            //         {
            //            SubjectId = 1,
            //            SubjectName = "Geography"
            //          },
            //            new Subjects
            //            {
            //                SubjectId = 3,
            //                SubjectName = "Physical Sciences"
            //            },

            //        ]
            //    }
            //    );

            //modelBuilder.Entity<Subjects>().HasData(
            //    new Subjects
            //    {
            //        SubjectId=1,
            //        SubjectName="Geography"
            //    },
            //     new Subjects
            //     {
            //         SubjectId = 2,
            //         SubjectName = "Accounting"
            //     },
            //      new Subjects
            //      {
            //          SubjectId = 3,
            //          SubjectName = "Physical Sciences"
            //      }
            //    );
        }
    }
}
