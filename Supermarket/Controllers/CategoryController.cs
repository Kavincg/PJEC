using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Data.IRepository;
using Supermarket.Models;
using Microsoft.AspNetCore.Hosting; // Added for IWebHostEnvironment
using System.IO; // Added for file operations

namespace Supermarket.Controllers
{
    //[Area("Admin")] // Uncomment if you use Areas for admin
    // [Authorize(Roles = SD.Role_Admin)] // Uncomment and ensure SD.Role_Admin is defined
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment; // Declare IWebHostEnvironment

        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) // Inject IWebHostEnvironment
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment; // Initialize it
        }

        public IActionResult Index()
        {
            List<Category> objCategoriesList = _unitOfWork.Categories.GetAll().ToList();
            return View("Index", objCategoriesList);
        }

        public IActionResult Index2(string search)
        {
            List<Category> objCategoriesList = _unitOfWork.Categories.GetAll().ToList();
            if (!string.IsNullOrEmpty(search))
            {
                objCategoriesList = objCategoriesList.Where(x => x.Name.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View("ViewForCustomer", objCategoriesList);
        }

        public IActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                List<Category> objCategoriesList = _unitOfWork.Categories.GetAll().ToList();
                objCategoriesList = objCategoriesList.Where(x => x.Name.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("ViewForCustomer", objCategoriesList);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj, IFormFile? file) // Added IFormFile? file parameter
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Category Name.");
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    //string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // Generate unique file name
                    string categoryPath = Path.Combine(wwwRootPath, @"img"); // Define server path for category images

                    if (!Directory.Exists(categoryPath))
                    {
                        Directory.CreateDirectory(categoryPath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(categoryPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.logoUrl = file.FileName;
                }

                _unitOfWork.Categories.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoriesFromDb = _unitOfWork.Categories.Get(u => u.id == id);

            if (CategoriesFromDb == null)
            {
                return NotFound();
            }

            return View(CategoriesFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string uploadFolder = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {
                    //string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // unique name
                    string filePath = Path.Combine(uploadFolder, file.FileName);

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.logoUrl = file.FileName;
                }

                _unitOfWork.Categories.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _unitOfWork.Categories.Get(u => u.id == id);
            if (obj == null)
            {
                return NotFound();
            }

            // Delete associated image when deleting category
            // Now, obj.logoUrl will just be the filename, so combine it with the base path
            if (!string.IsNullOrEmpty(obj.logoUrl))
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                var imagePath = Path.Combine(wwwRootPath, @"images\category", obj.logoUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _unitOfWork.Categories.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Pagination(int page = 1, int pageSize = 4)
        {
            return View("Pagination", _unitOfWork.Categories.GetAll());
        }
    }
}