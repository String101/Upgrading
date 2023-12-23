using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace Upgrading.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        private readonly ISubject _subject;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public StudentController(IStudent student, ISubject subject,SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> usermanager,IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _student = student;
            _subject = subject;
            _signinManager = signInManager;
            _usermanager = usermanager;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var username = _usermanager.GetUserName(User);

            ApplicationUser user = _unitOfWork.User.Get(x => x.UserName == username);
            if(user.Role==SD.Role_Admin)
            {
                var students = _student.GetAll();
                return View(students);
            }
            else
            {

                var students = _student.Get(u => u.StudentId == user.StudentId);
                if(students==null)
                {
                    return RedirectToAction("Create", "Student");
                }
                else
                {
                    return View("StudentIndex", students);
                }
                
            }
            
           

           
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> sub = _subject.GetAll().Select(u => new SelectListItem
            {
                Value=u.SubjectName,
                Text=u.SubjectName
            });
        
            ViewBag.Subjects = sub;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            var username = _usermanager.GetUserName(User);
            if (ModelState.IsValid)
            {
                if(student.StudentIdentityCard!=null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(student.StudentIdentityCard.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"ids\studentsIdCopy");

                    using var fileStream = new FileStream(Path.Combine(imagePath, filename), FileMode.Create);
                   student.StudentIdentityCard.CopyTo(fileStream);

                    student.IdentityCardUrl = @"\ids\studentsIdCopy\" + filename;
                }
                if(student.MatricStatement!=null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(student.MatricStatement.FileName);
                    string statementPath = Path.Combine(_webHostEnvironment.WebRootPath, @"statements\ApplicantsMatricStatement");

                    using var fileStream = new FileStream(Path.Combine(statementPath, filename), FileMode.Create);
                    student.MatricStatement.CopyTo(fileStream);

                    student.StatementUrl = @"\statements\ApplicantsMatricStatement\" + filename;

                }
                ApplicationUser user = _unitOfWork.User.Get(x => x.UserName == username);
                student.StudentId = $"{DateTime.Now.Year}" + new Random().Next(100) + $"{DateTime.Now.Day}" + new Random().Next(9);
                user.StudentId = student.StudentId;
                student.StudentName = user.StudentName;
                student.StudentSurname = user.StudentSurname;
                student.Email = user.Email;
                _student.Add(student);
                _student.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

            
        }
       
        [HttpGet]
        public IActionResult Details(string id)
        {
            var student = _student.Get(u => u.StudentId == id);
            return View(student);
        }
        public ICollection<Subjects> GetSubjectById(List<string> id)
        {
            List<Subjects> subjects=new List<Subjects>();
            foreach(var idItem in id)
            {
                Subjects subjects1=_subject.Get(u=>u.SubjectId == idItem);
                subjects.Add(subjects1);
            }
           return subjects;
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var subject = _student.Get(u => u.StudentId == id) ;
            IEnumerable<SelectListItem> sub = _subject.GetAll().Select(u => new SelectListItem
            {
                Value = u.SubjectName,
                Text = u.SubjectName
            });

            ViewBag.Subjects = sub;
            return View(subject);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {

            _student.Update(student);
            _student.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var student = _student.Get(u => u.StudentId == id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            Student? objFromDb = _student.Get(u => u.StudentId == student.StudentId);
            if(objFromDb is not null)
            {
                if (!string.IsNullOrEmpty(objFromDb.IdentityCardUrl))
                {
                    var oldIDPath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.IdentityCardUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldIDPath))
                    {
                        System.IO.File.Delete(oldIDPath);
                    }
                }
                if (!string.IsNullOrEmpty(objFromDb.StatementUrl))
                {
                    var oldIDPath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.StatementUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldIDPath))
                    {
                        System.IO.File.Delete(oldIDPath);
                    }
                }
            }
            _student.Remove(objFromDb);
            _student.Save();
            return RedirectToAction(nameof(Index));
        }
      public IActionResult DownloadID(Student student)
      {
            Student? objFromDb = _student.Get(u => u.StudentId == student.StudentId);
            if(objFromDb is not null)
            {
                if(!string.IsNullOrEmpty(objFromDb.IdentityCardUrl))
                {
                    var oldIDPath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.IdentityCardUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldIDPath))
                    {
                        byte[] fileBytes = System.IO.File.ReadAllBytes(oldIDPath);
                        string contentType = "application/octet-stream";
                        return File(fileBytes, contentType, oldIDPath);
                    }
                }
                else
                {
                    // If the file doesn't exist, return a 404 Not Found response
                    return NotFound();
                }
            }
            else
            {
                return View();
            }
            return View();

      }
        public IActionResult DownloadStatement(Student student)
        {
            Student? objFromDb = _student.Get(u => u.StudentId == student.StudentId);
            if (objFromDb is not null)
            {
                if (!string.IsNullOrEmpty(objFromDb.StatementUrl))
                {
                    var oldIDPath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.StatementUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldIDPath))
                    {
                        byte[] fileBytes = System.IO.File.ReadAllBytes(oldIDPath);
                        string contentType = "application/octet-stream";
                        return File(fileBytes, contentType, oldIDPath);
                    }
                }
                else
                {
                    // If the file doesn't exist, return a 404 Not Found response
                    return NotFound();
                }
            }
            else
            {
                return View();
            }
            return View();

        }
    }
}
