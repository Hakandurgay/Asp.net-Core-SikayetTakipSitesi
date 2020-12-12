using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;

namespace SikayetTakipSitesi.Controllers
{
    public class CategoryBrandController : Controller
    {
        private readonly SikayetDbContext _context;


        public CategoryBrandController(SikayetDbContext context)
        {
            _context = context;
        }


        CategoryBrandModelView categoryBrandViewModel = new CategoryBrandModelView();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //   categoryBrandViewModel.CategoryBrand =await _context.CategoryBrands.Include(c => c.Brand).Where(z=>z.Brand.BrandStatus==true).Include(c => c.Category).Where(z=>z.Category.CategoryStatus==true).ToListAsync();
            categoryBrandViewModel.Brand = await _context.CategoryBrands.Include(x => x.Brand).Where(y => y.Brand.BrandStatus == true).ToListAsync();

            categoryBrandViewModel.Category = await _context.CategoryBrands.Include(x => x.Category).Where(y => y.Category.CategoryStatus == true).ToListAsync();
            return View(categoryBrandViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            categoryBrandViewModel.Category = await _context.CategoryBrands.Include(x => x.Category).Where(y => y.Category.CategoryStatus == true).ToListAsync();
            categoryBrandViewModel.Brand = await _context.CategoryBrands.Include(x => x.Brand).Where(y => y.BrandId == id &&  y.Brand.BrandStatus == true).ToListAsync();
      
            return View(categoryBrandViewModel);
        }

    }
}
