using Microsoft.AspNetCore.Mvc;

namespace ElectroWave.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList=context.Categories.ToList();
            return View(CategoryList);
        }

    }
}
