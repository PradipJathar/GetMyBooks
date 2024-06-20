using GetMyBooksRazor.Data;
using GetMyBooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetMyBooksRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public List<Category> CategoryList { get; set; }


        public IndexModel(ApplicationDbContext context)
        {
            db = context;
        }


        public void OnGet()
        {
            this.CategoryList = db.Categories.ToList();
        }
    }
}
