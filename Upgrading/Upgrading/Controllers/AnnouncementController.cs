using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Controllers
{
    [Authorize]
    public class AnnouncementController : Controller
    {

        private readonly IAnnouncement _announcement;

        public AnnouncementController(IAnnouncement announcement)
        {
            _announcement = announcement;
        }
        public IActionResult Index()
        {
            IEnumerable<Announcement> announcements = _announcement.GetAll();
            return View(announcements);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Announcement announcement)
        {
            _announcement.Add(announcement);
            _announcement.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Announcement announcement =_announcement.Get(u=>u.Id == id);
            return View(announcement);
        }
        [HttpPost]
        public IActionResult Update(Announcement announcement)
        {
           _announcement.Update(announcement);
            _announcement.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Announcement announcement = _announcement.Get(u => u.Id == id);
            return View(announcement);
        }
        [HttpPost]
        public IActionResult Delete(Announcement announcement)
        {
            _announcement.Remove(announcement);
            _announcement.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
