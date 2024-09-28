using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStoreRazor_Temp.Data;
using WebStoreRazor_Temp.Model;

namespace WebStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;
        
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(Category);
                db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
