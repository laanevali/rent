using Microsoft.AspNetCore.Mvc;

namespace rent.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
