using Microsoft.AspNetCore.Mvc;
using rent.Models;
using rent.Repository;

namespace rent.Controllers
{
    public class CarController : Controller
    {
        private readonly IData data;

        public CarController(IData _data)
        {
            data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car newcar)
        {
            if (!ModelState.IsValid)
                return View(newcar);
            bool isSaved = data.AddNewCar(newcar);
            ViewBag.isSaved = isSaved;
            ModelState.Clear();
            return View();
        }
    }
}
