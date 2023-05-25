using Microsoft.AspNetCore.Mvc;
using rent.Models;
using rent.Repository;

namespace rent.Controllers
{
    public class DriverController : Controller
    {
        private readonly IData data;
        public DriverController(IData _data)
        {
            data = _data;
        }
        public IActionResult Index()
        {
            var list = data.GetAllDrivers();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Driver driver)
        {
            if (!ModelState.IsValid)
                return View(driver);
            ViewBag.isSaved = data.AddDriver(driver);
            ModelState.Clear();
            return View();
        }
        public IActionResult History(int Id)
        {
            var list = data.GetDriverHistory(Id);
            return View(list);
        }
    }
}
