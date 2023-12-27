using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.AspNetCore.Mvc;

namespace Upgrading.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var subject = _unitOfWork.Subject.GetAll();
            return View(subject);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subjects  subjects)
        {
        
            subjects.SubjectId= Guid.NewGuid().ToString();
            _unitOfWork.Subject.Add(subjects);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
           var subject= _unitOfWork.Subject.Get(u=>u.SubjectId==id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Update(Subjects subjects)
        {
            _unitOfWork.Subject.Update(subjects);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var subject = _unitOfWork.Subject.Get(u => u.SubjectId == id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Delete(Subjects subjects)
        {
            _unitOfWork.Subject.Remove(subjects);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
