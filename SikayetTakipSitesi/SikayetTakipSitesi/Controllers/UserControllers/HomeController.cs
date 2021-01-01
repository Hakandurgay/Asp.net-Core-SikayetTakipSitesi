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

            ViewBag.MarkaSayisi = _context.Brands.Count().ToString();
            ViewBag.MusteriSayisi = _context.Members.Count().ToString();
            ViewBag.SikayetSayisi = _context.Complaints.Count().ToString();
            ViewBag.YorumSayisi = _context.Comments.Count().ToString();


            homeViewModel.Brands = await _context.Brands.ToListAsync();

            homeViewModel.BrandNames = await _context.Complaints.GroupBy(x => x.FK_BRAND_ID.BrandName).OrderByDescending(z => z.Count()).Select(k => k.Key).ToListAsync();

            return View(homeViewModel);
        }


    }
}

