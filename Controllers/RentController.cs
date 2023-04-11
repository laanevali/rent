using Microsoft.AspNetCore.Mvc;

namespace rent.Controllers
{
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
