using Upgrading.Interface;
using Upgrading.Models;
using Microsoft.AspNetCore.Mvc;

namespace Upgrading.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubject _subject;
        
        public SubjectController(ISubject subject)
        {
            _subject = subject;
        }
        public IActionResult Index()
        {
            var subject = _subject.GetAll();
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
            _subject.Add(subjects);
            _subject.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
           var subject= _subject.Get(u=>u.SubjectId==id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Update(Subjects subjects)
        {
            _subject.Update(subjects);
            _subject.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var subject = _subject.Get(u => u.SubjectId == id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Delete(Subjects subjects)
        {
            _subject.Remove(subjects);
            _subject.Save();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
