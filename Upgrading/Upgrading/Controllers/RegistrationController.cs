using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public RegistrationController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _usermanager = usermanager;
            _signinManager = signinManager;
        }
        [Authorize(Roles =SD.Role_Admin)]
        public IActionResult Index()
        {
            var registration = _unitOfWork.Registration.GetAll(includeProperties: "Student");
            return View(registration);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var username = _usermanager.GetUserName(User);

            ApplicationUser user = _unitOfWork.User.Get(x => x.UserName == username);

            Student student = _unitOfWork.Student.Get(u => u.StudentId == user.StudentId);
            if (student is not null)
            {
                if (student.Status == SD.StatuseApproved)
                {
                    Registration registration = new()
                    {
                        Student = student,
                        StudentId = student.StudentId,
                    };
                    return View(registration);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
              
                
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
           
        }
        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            var username = _usermanager.GetUserName(User);

            ApplicationUser user = _unitOfWork.User.Get(x => x.UserName == username);
            bool re = _unitOfWork.Registration.Any(u => u.StudentId == user.StudentId);
            if (re==false)
            {
                if (registration.RegistrationFee != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(registration.RegistrationFee.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, @"statements\RegistrationPayment");

                    using var fileStream = new FileStream(Path.Combine(filePath, filename), FileMode.Create);
                    registration.RegistrationFee.CopyTo(fileStream);

                    registration.RegistrationFeeUrl = @"\statements\RegistrationPayment\" + filename;
                }

                Student student = _unitOfWork.Student.Get(u => u.StudentId == registration.StudentId);
                registration.Student = student;
                _unitOfWork.Registration.Add(registration);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }else
            {
                return RedirectToAction("Index", "Home");
            }

            

        }
    }
}
