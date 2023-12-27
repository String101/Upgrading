using Microsoft.AspNetCore.Mvc;

namespace Upgrading.Controllers
{
    public class TimetableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
