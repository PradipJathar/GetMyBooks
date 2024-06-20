using GetMyBooksRazor.Data;
using GetMyBooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetMyBooksRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public Category Category { get; set; }


        public EditModel(ApplicationDbContext context)
        {
            db = context;
        }


        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(Category);
                db.SaveChanges();

                TempData["success"] = "Category edited successfully.";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
