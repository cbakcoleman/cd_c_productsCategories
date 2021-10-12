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

        [HttpGet("products")]
        public IActionResult Products()
        {
            ViewBag.AllProducts = _context.Products.
                Include(p => p.ProductName).
                OrderByDescending(p => p.CreatedAt).
                ToList();

            return View("Products");
        } 
    }
}