using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Filters;
using SikayetTakipSitesi.Models;
using X.PagedList;

namespace SikayetTakipSitesi.Controllers.AdminControllers
{

    [UserFilter]
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

        public IActionResult CategoryProcess(int sayfa=1)
        {
            var categoryValues = _context.Categories.Where(x => x.CategoryStatus == true).ToList().ToPagedList(sayfa,5);

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
