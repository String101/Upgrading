using Upgrading.Data;
using Upgrading.Interface;

namespace Upgrading.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SQLiteDbContext _db;
        

        public IApplicationUser User { get; private set; }

        public IStudent Student { get; private set; }

        public ISubject Subject { get; private set; }

        public IAnnouncement Announcement { get; private set; }

        public IProduct Product { get; private set; }

        public UnitOfWork(SQLiteDbContext db)
        {
            _db = db;
            User = new ApplicationUserRepo(_db);
            Student = new StudentRepo(_db);
            Subject = new SubjectRepo(_db);
            Announcement = new AnnouncementRepo(_db);
            Product = new ProductRepo(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
