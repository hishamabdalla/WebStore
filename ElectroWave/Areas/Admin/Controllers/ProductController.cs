using ElectroWave.DataAccess.Repository.IRepository;
using ElectroWave.Models;
using ElectroWave.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectroWave.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment )
        {
            this._unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            

        }
        public IActionResult Index()
        {
            List<Product> ProductsList = _unitOfWork.Product.GetAll().ToList();
            return View(ProductsList);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()

            };
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                 productVM.Product = _unitOfWork.Product.Get(c => c.Id == id);
                return View(productVM);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file) //Update and Insert
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath=_webHostEnvironment.WebRootPath;
               if(file != null)
               {
                    string fileName=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                    string productPath=Path.Combine(wwwRootPath, @"assets\Images\Product");

                    using (var stream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(stream);
                    };

                    productVM.Product.ImageURL = @"assets\Images\Product" + fileName;
                    
               }
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
               productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
               {
                    Text = u.Name,
                    Value = u.Id.ToString()
               });
     
                return View(productVM);

            }
        }
      
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _unitOfWork.Product.Get(c => c.Id == id);
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var productFromDb = _unitOfWork.Product.Get(c => c.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully";

            return RedirectToAction("Index");

        }

       
    }

}
