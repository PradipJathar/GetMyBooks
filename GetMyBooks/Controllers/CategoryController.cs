using GetMyBooks.Data;
using GetMyBooks.Migrations;
using GetMyBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetMyBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = db.Categories.ToList();

            return View(categoryList);
        }
        
        public IActionResult Create()
        {            
            return View();
        }
    }
}
