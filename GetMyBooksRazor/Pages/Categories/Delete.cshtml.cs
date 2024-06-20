using GetMyBooksRazor.Data;
using GetMyBooksRazor.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetMyBooksRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public Category Category { get; set; }


        public DeleteModel(ApplicationDbContext context)
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
            Category? category = db.Categories.Find(Category.Id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
