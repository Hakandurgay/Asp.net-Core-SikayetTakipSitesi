﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Filters;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;
using X.PagedList;

namespace SikayetTakipSitesi.Controllers
{
    [UserFilter]

    public class CategoryBrandController : Controller
    {
        private readonly SikayetDbContext _context;


        public CategoryBrandController(SikayetDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //   categoryBrandViewModel.CategoryBrand =await _context.CategoryBrands.Include(c => c.Brand).Where(z=>z.Brand.BrandStatus==true).Include(c => c.Category).Where(z=>z.Category.CategoryStatus==true).ToListAsync();
            var brands = await _context.Brands.Where(b => b.BrandStatus == true).ToListAsync();
            return View(brands);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            //categoryBrandViewModel.Category = await _context.CategoryBrands.Include(x => x.Category).Where(y => y.Category.CategoryStatus == true).ToListAsync();
            //categoryBrandViewModel.Brand = await _context.CategoryBrands.Include(x => x.Brand).Where(y => y.BrandId == id &&  y.Brand.BrandStatus == true).ToListAsync();
            //return View(categoryBrandViewModel);
            var categoryBrands = await _context.CategoryBrands.Include(cb => cb.Brand).Where(y => y.Category.CategoryStatus == true && y.CategoryId == id).ToListAsync();
                var brands = new List<Brand>();
            foreach (CategoryBrand categoryBrand in categoryBrands)  //viewmodel yapıp categorybrandi viewa yollayıp orada tekrar foreach ile içinde geziceğimiz için performans arttırmak için burada yani viewa yollamadan ayrılıp gönderiliyor
            {
                brands.Add(categoryBrand.Brand);
            }
            return View(brands);
        }

    }
}
