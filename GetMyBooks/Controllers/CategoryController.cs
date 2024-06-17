using Microsoft.AspNetCore.Mvc;

namespace GetMyBooks.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
