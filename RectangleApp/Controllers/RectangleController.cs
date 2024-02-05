using Microsoft.AspNetCore.Mvc;
using RectangleApp.Models;
namespace RectangleApp.Controllers
{
    public class RectangleController : Controller
    {
        private readonly IRectangleService _rectangleService;

        public RectangleController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRectangle(Rectangle model)
        {
            if (ModelState.IsValid)
            {
                
                double heightInMeters = ConvertToMeters(model.Height, model.HeightUnit);
                double widthInMeters = ConvertToMeters(model.Width, model.WidthUnit);

                var rectangle = new Rectangle
                {
                    Height = heightInMeters,
                    Width = widthInMeters,
                    HeightUnit = "m", 
                    WidthUnit = "m",
                    CreatedAt = DateTime.Now
                };

                _rectangleService.AddRectangle(rectangle);
                return RedirectToAction("Result", new { id = rectangle.Id });
            }
            return View("Index", model);
        }

        private double ConvertToMeters(double value, string unit)
        {
            switch (unit)
            {
                case "mm":
                    return value / 1000; 
                case "cm":
                    return value / 100; 
                case "m":
                    return value; 
                default:
                    throw new ArgumentException("Nieznana jednostka", nameof(unit));
            }
        }
        public IActionResult Result(int id)
        {       
            var rectangle = _rectangleService.GetRectangleById(id);
            if (rectangle == null)
            {
                return NotFound();
            }
            return View(rectangle);
        }

        public IActionResult List()
        {
            var rectangles = _rectangleService.GetAllRectangles();          
            return View(rectangles);
        }
        public IActionResult Delete(int id)
        {
            _rectangleService.DeleteRectangle(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rectangle = _rectangleService.GetRectangleById(id);
            if (rectangle == null)
            {
                return NotFound();
            }
            return View(rectangle);
        }
        [HttpPost]
        public IActionResult Edit(int id, Rectangle rectangle)
        {
            if (ModelState.IsValid)
            {
                _rectangleService.UpdateRectangle(id, rectangle);
                return RedirectToAction("List");
            }
            return View(rectangle);
        }
    }
}
