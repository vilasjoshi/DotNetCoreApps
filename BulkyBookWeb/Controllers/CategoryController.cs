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
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            //custome erro
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomeError", "Display order and name cannot be same");
            }

            if (category.DisplayOrder < 0)
            {
                ModelState.AddModelError("Invalid Details", "Display order cannot be negative.");
            }

            //validate the values;
            //is valid model incoming 
            if (!ModelState.IsValid)
            {
                return View(category);
            }
             
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryById = _context.Categories.Find(id);
            //var categoryByIdSingle = _context.Categories.SingleOrDefault(u => u.Id == id);
            //var categoryByIdFirst = _context.Categories.FirstOrDefault( u => u.Id == id);
            if (categoryById == null)
                return NotFound();

            return View(categoryById);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            //custome erro
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomeError", "Display order and name cannot be same");
            }

            if (category.DisplayOrder < 0)
            {
                ModelState.AddModelError("Invalid Details", "Display order cannot be negative.");
            }

            //validate the values;
            //is valid model incoming 
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["success"] = "Category Updated Successfully.";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryById = _context.Categories.Find(id);
            //var categoryByIdSingle = _context.Categories.SingleOrDefault(u => u.Id == id);
            //var categoryByIdFirst = _context.Categories.FirstOrDefault( u => u.Id == id);
            if (categoryById == null)
                return NotFound();

            return View(categoryById);
        }
        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }


            _context.Categories.Remove(category);
            _context.SaveChanges();

            TempData["success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index");
        }


    }
}
