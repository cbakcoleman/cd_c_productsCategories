using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using cd_c_productsCategories.Models;

namespace cd_c_productsCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult index()
        {
            return RedirectToAction("products");
        }

        [HttpGet("products")]
        public IActionResult products()
        {
            ViewBag.AllProducts = _context.Products.
                OrderByDescending(p => p.CreatedAt).
                ToList();

            return View("products");
        } 

        [HttpPost("addproduct")]
        public IActionResult addproduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            else
            {
                ViewBag.AllProducts = _context.Products.
                OrderByDescending(p => p.CreatedAt).
                ToList();

                return View("products", product);
            }
        }

        [HttpGet("categories")]
        public IActionResult categories()
        {
            ViewBag.AllCategories = _context.Categories.
            OrderByDescending(p => p.CreatedAt).
            ToList();

            return View("categories");
        }

        [HttpPost("addcategory")]
        public IActionResult addcategory(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("categories");
            }
            else
            {
                ViewBag.AllCategories = _context.Categories.
                OrderByDescending(p => p.CreatedAt).
                ToList();

                return View("categories", category);
            }
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult thiscategory(int categoryId)
        {
            ViewBag.thiscategory = _context.Categories
            .Include(cat => cat.Products)
            .ThenInclude(prod => prod.Product)
            .SingleOrDefault(p => p.CategoryId == categoryId);

            // ViewBag.NotCategoryProducts = _context.Products
            // .Include(prod => prod.Categories)
            // .ThenInclude(cat => cat.Category)
            // .Where(prod => prod.Categories.CategoryId != categoryId)
            // .ToList();

            ViewBag.AllProducts = _context.Products
            .Include(prod => prod.Categories)
            .OrderByDescending(p => p.CreatedAt).
            ToList();


            // List<Product> AllProducts = _context.Products
            // .Include(prod => prod.Categories)
            // .ThenInclude(cat => cat.CategoryId)
            // .Where(cat => cat.Categories.)

            // foreach(var prod in AllProducts)
            // {
            //     foreach(var cat in prod.Categories)
            //     {
            //         System.Console.WriteLine(cat.Category.CategoryName);
            //     }
            // }
            
            return View("categorieshasproducts");
        }
        
        [HttpPost("addproducttocategory")]
        public IActionResult addproducttocategory(ProductsHasCategories productshascategories)
        {
            if(ModelState.IsValid)
            {
                _context.Add(productshascategories);
                _context.SaveChanges();
                return Redirect($"/categories/{productshascategories.CategoryId}");
            }
            else
            {
                return View("categorieshasproducts", productshascategories);
            }
        }

        [HttpGet("products/{productId}")]
        public IActionResult thispoduct(int productId)
        {
            ViewBag.thisproduct = _context.Products
            .Include(prod => prod.Categories)
            .ThenInclude(cat => cat.Category)
            .SingleOrDefault(p => p.ProductId == productId);

            ViewBag.AllCategories = _context.Categories
            .Include(cat => cat.Products)
            .OrderByDescending(p => p.CreatedAt)
            .ToList();

            
            return View("productshascategories");
        }

        [HttpPost("addcategorytoproduct")]
        public IActionResult addcategorytoproduct(ProductsHasCategories productshascategories)
        {
            if(ModelState.IsValid)
            {
                _context.Add(productshascategories);
                _context.SaveChanges();
                return Redirect($"/products/{productshascategories.ProductId}");
            }
            else
            {
                return View("productshascategories", productshascategories);
            }
        }
    }
}