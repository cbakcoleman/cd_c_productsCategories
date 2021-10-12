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
    }
}