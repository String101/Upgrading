using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Controllers
{
  
    public class AnnouncementController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Announcement> announcements = _unitOfWork.Announcement.GetAll();
            return View(announcements);
        }
        [HttpGet]
        [Authorize(Roles =SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create(Announcement announcement)
        {
            _unitOfWork.Announcement.Add(announcement);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Update(int id)
        {
            Announcement announcement =_unitOfWork.Announcement.Get(u=>u.Id == id);
            return View(announcement);
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Update(Announcement announcement)
        {
           _unitOfWork.Announcement.Update(announcement);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int id)
        {
            Announcement announcement = _unitOfWork.Announcement.Get(u => u.Id == id);
            return View(announcement);
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(Announcement announcement)
        {
            _unitOfWork.Announcement.Remove(announcement);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
