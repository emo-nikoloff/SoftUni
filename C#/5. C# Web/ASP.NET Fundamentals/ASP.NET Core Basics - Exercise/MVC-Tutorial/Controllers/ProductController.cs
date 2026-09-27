using Microsoft.AspNetCore.Mvc;

namespace MVC_Tutorial.Controllers
{
    public class ProductController : Controller
    {
        private static readonly IEnumerable<string> products = new List<string>
        {
            "Laptops",
            "Desktops",
            "Tablets",
        };

        public IActionResult Index()
        {
            ViewData["Products"] = products;

            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Something was wrong with your request. Please try again!");
            }

            if (id <= 0)
            {
                return NotFound("Product not found.");
            }

            return Ok($"Product details: {id}");
        }
    }
}
