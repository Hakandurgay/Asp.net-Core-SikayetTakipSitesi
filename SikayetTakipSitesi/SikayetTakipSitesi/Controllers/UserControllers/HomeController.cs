using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Filters;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {

        private readonly SikayetDbContext _context;
        HomeViewModel homeViewModel;
        public HomeController(SikayetDbContext context)
        {
            this._context = context;
            homeViewModel = new HomeViewModel();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            



            homeViewModel.Complaint = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(z => z.ComplaintStatus == true).ToListAsync();
            var most = _context.Complaints.GroupBy(i => i.FK_BRAND_ID.BrandName).OrderByDescending(grp => grp.Count());




            //List<Brand> brands = new List<Brand>();
            ////   categoryBrandViewModel.CategoryBrand =await _context.CategoryBrands.Include(c => c.Brand).Where(z=>z.Brand.BrandStatus==true).Include(c => c.Category).Where(z=>z.Category.CategoryStatus==true).ToListAsync();
            //List<Complaint> complaints = await _context.Complaints.Include(x => x.FK_BRAND_ID).ToListAsync();
            return View(homeViewModel);
        }

        //    [HttpPost]
        //public async Task<IActionResult> Index(int id)
        //{
        //    //categoryBrandViewModel.Category = await _context.CategoryBrands.Include(x => x.Category).Where(y => y.Category.CategoryStatus == true).ToListAsync();
        //    //categoryBrandViewModel.Brand = await _context.CategoryBrands.Include(x => x.Brand).Where(y => y.BrandId == id &&  y.Brand.BrandStatus == true).ToListAsync();

        //    //return View(categoryBrandViewModel);
        //    //List<CategoryBrand> categoryBrands = await _context.CategoryBrands.OrderBy(cb => cb.Brand).Where(y => y.Category.CategoryStatus == true && y.CategoryId == id).ToListAsync();
        //    List<Brand> brands = new List<Brand>();
        //    //foreach (CategoryBrand categoryBrand in categoryBrands)  //viewmodel yapıp categorybrandi viewa yollayıp orada tekrar foreach ile içinde geziceğimiz için performans arttırmak için burada yani viewa yollamadan ayrılıp gönderiliyor
        //    //{
        //    //    brands.Add(categoryBrand.Brand);
        //    //}

        //    //return View(await _context.Brands.OrderBy(a => a.BrandId).ToListAsync());
        //    return View(brands);
        //}
    }
}

