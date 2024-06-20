using GetMyBooksRazor.Data;
using GetMyBooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetMyBooksRazor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public Category Category { get; set; }


        public CreateModel(ApplicationDbContext context)
        {
            db = context;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        { 
            db.Categories.Add(Category);
            db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
