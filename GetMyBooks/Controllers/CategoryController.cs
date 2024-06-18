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

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder can not exactly match Name.");
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

                return RedirectToAction("Index"); 
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
