using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.Controllers.AdminControllers
{
    public class AdminCategoryPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly SikayetDbContext _context;

        public AdminCategoryPage(SikayetDbContext context)
        {
            this._context = context;
        }

        public IActionResult CategoryProcess()
        {
            List<Category> categoryValues = _context.Categories.Where(x => x.CategoryStatus == true).ToList();

            return View(categoryValues);
        }
        public IActionResult GetCategory(int id)
        {
            var kategori = _context.Categories.Find(id);
            return View("UpdateCategory", kategori);
        }

        public IActionResult UpdateCategory(Category category)
        {
            category.CategoryStatus = true;
            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("CategoryProcess");
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryProcess");
        }
        public IActionResult DeleteCategory(int id)
        {
            //  (_context.Comments.Select(z => z.MemberId))

            var category = _context.Categories.Find(id);
            category.CategoryStatus = false;
            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("CategoryProcess");
        }
    }
}
