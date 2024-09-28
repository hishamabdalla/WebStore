using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStoreRazor_Temp.Data;
using WebStoreRazor_Temp.Model;

namespace WebStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
           
                db.Categories.Remove(Category);
                db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            
        }
    }
}
