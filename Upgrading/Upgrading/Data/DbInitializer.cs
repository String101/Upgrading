using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SQLiteDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public DbInitializer(SQLiteDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            { 
                  if(_db.Database.GetPendingMigrations().Count()>0)
                  {
                        _db.Database.Migrate();
                  }
                if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).Wait();
                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin@fundanathi.com",
                        Email = "admin@fundanathi.com",
                        StudentName = "Sihle",
                        PhoneNumber = "0657290039",
                        NormalizedUserName = "ADMIN@FUNDANATHI.COM",
                        NormalizedEmail = "ADMIN@FUNDANATHI.COM",
                        StudentSurname = "Sithole"
                    }, "AdminFMU123*").GetAwaiter().GetResult();
                    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@fundanathi.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                }
            }
                
            catch(Exception ex) 
            {
                throw;
            }
        }
    }
}
