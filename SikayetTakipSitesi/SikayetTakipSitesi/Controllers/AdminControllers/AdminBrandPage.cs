using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.Controllers.AdminControllers
{
    public class AdminBrandPage : Controller
    {
        private readonly SikayetDbContext _context;

        public AdminBrandPage(SikayetDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BrandProcess()
        {
            List<Brand> brandValues = _context.Brands.Where(x => x.BrandStatus == true).ToList();

            return View(brandValues);

        }
        public IActionResult GetBrand(int id)
        {
            var marka = _context.Brands.Find(id);
            return View("UpdateBrand", marka);
        }

        public IActionResult UpdateBrand(Brand brand)
        {
            brand.BrandStatus = true;
            _context.Brands.Update(brand);
            _context.SaveChanges();

            return RedirectToAction("BrandProcess");
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            brand.BrandStatus = true;
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("BrandProcess");
        }

        public IActionResult DeleteBrand(int id)
        {
            var brand = _context.Brands.Find(id);
            brand.BrandStatus = false;
            _context.Brands.Update(brand);
            _context.SaveChanges();
            return RedirectToAction("BrandProcess");
        }
    }
}
