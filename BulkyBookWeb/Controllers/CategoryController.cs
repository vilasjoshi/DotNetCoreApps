using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
