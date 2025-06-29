﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Supermarket.Data.IRepository;
using Supermarket.Models;
using Supermarket.RolesAndEmailSender;
using Supermarket.ViewModel;
using System.Security.Claims;

namespace Supermarket.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string search)
        {
            ViewBag.Categories = _unitOfWork.Categories.GetAll().ToList();
            List<Product> productList = _unitOfWork.Products.GetAll().ToList();
            if (!string.IsNullOrEmpty(search))
            {
                productList = productList.Where(x => x.Name.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(productList);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _unitOfWork.Categories.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM productvm)
        {
            if (ModelState.IsValid)
            {
                if (productvm.ProductImage != null)
                {
                    string ImageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    string ImagePath = Path.Combine(ImageFolder, productvm.ProductImage.FileName);
                    productvm.ProductImage.CopyTo(new FileStream(ImagePath, FileMode.Create));
                    Product product = new Product();
                    product.imgURL = productvm.ProductImage.FileName;

                    product.Name = productvm.Name;
                    product.Description = productvm.Description;
                    product.price = productvm.price;
                    product.CategoryId = productvm.CategoryId;

                    _unitOfWork.Products.Add(product);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            return View(productvm);
        }

        public IActionResult Edit(int? id)
        {

            Product? productfromDB = _unitOfWork.Products.Get(x => x.Id == id);

            ProductVM productvm = new();
            productvm.Id = productfromDB.Id;
            productvm.Name = productfromDB.Name;
            productvm.Description = productfromDB.Description;
            productvm.price = productfromDB.price;
            productvm.CategoryId = productfromDB.CategoryId;
            productvm.imgURL = productfromDB.imgURL;

            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            return View(productvm);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productvm)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();

                if (productvm.ProductImage != null)
                {
                    string ImageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
                    string ImagePath = Path.Combine(ImageFolder, productvm.ProductImage.FileName);
                    productvm.ProductImage.CopyTo(new FileStream(ImagePath, FileMode.Create));
                    
                    product.imgURL = productvm.ProductImage.FileName;

                }
                else
                {
                    product.imgURL = productvm.imgURL;
                }

                product.Id = productvm.Id;
                product.Name = productvm.Name;
                product.Description = productvm.Description;
                product.price = productvm.price;
                product.CategoryId = productvm.CategoryId;

                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            return View(productvm);
        }


        public IActionResult Delete(int? id)
        {
            Product obj = _unitOfWork.Products.Get(x => x.Id == id);
            _unitOfWork.Products.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            // TempData["ProductError"] = TempData["ProductError"];
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Products.Get(p => p.Id == id),
                productId = id,
                quantity = 1
            };

            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCart cartFromDb = _unitOfWork.Carts.Get(u => u.ApplicationUserId == userId &&
            u.productId == shoppingCart.productId);

            if (cartFromDb != null)
            {
                
                cartFromDb.quantity += shoppingCart.quantity;
            }
            else
            {
               
                ShoppingCart shoppingMapping = new()
                {
                    quantity = shoppingCart.quantity,
                    productId = shoppingCart.productId,
                    ApplicationUserId = userId,
                    Product = _unitOfWork.Products.Get(p => p.Id == shoppingCart.productId)
                };
                _unitOfWork.Carts.Add(shoppingMapping);
                //HttpContext.Session.SetInt32(SD.SessionCart,
            }
            _unitOfWork.Save();
            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult FindByCategory(int categoryId)
        {
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            var favproducts = _unitOfWork.Products.FilterBy(categoryId);
            return View("Index", favproducts);
        }

        [Authorize]
        public async Task<IActionResult> Favourite(int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currUser = await _unitOfWork.ApplicationUser.GetAsync(x => x.Id == userId);


            var favourite = await _unitOfWork.Favorites.GetAsync(x => x.ProductId == productId && x.UserId == currUser.Id);
            bool isFavorited;

            if (favourite == null)
            {
                Favourite item = new()
                {
                    UserId = currUser.Id,
                    ProductId = productId,
                };
                await _unitOfWork.Favorites.AddAsync(item);
                isFavorited = true;
            }
            else
            {
                await _unitOfWork.Favorites.RemoveAsync(favourite);
                isFavorited = false;
            }

            await _unitOfWork.SavaAsync();

            return Json(new { isFavorited });
        }


        [Authorize]
        public async Task<IActionResult> GetFavs()
        {
            ViewBag.Categories = _unitOfWork.Categories.GetAll();

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currUser = await _unitOfWork.ApplicationUser.GetAsync(x => x.Id == userId);

            var favourites = await _unitOfWork.Favorites
     .FindAllAsync(x => x.UserId == currUser.Id, includeProperties: "Product");


            List<Product> products = new List<Product>();

            foreach (var favourite in favourites)
            {
                favourite.Product.IsFavorited = true;
                products.Add(favourite.Product);
            }
            var Products = favourites.Select(f =>
            {
                f.Product.IsFavorited = true;
                return f.Product;
            }).ToList();

            ViewBag.Fav = "My Favorites";

            return View("Favorites", products);
        }


    }
}




