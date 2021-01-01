using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Filters;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;

namespace SikayetTakipSitesi.Controllers
{
    [UserFilter]
    public class ComplaintController : Controller
    {
        private readonly SikayetDbContext _context;

        int id;
        public ComplaintController(SikayetDbContext context)
        {
            _context = context;
        }
        ComplaintViewModel brand_ViewModel = new ComplaintViewModel();


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.kontrol = "get";
            ViewBag.markaAd = _context.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            ViewBag.kontrol = "post";
            brand_ViewModel.Brand = _context.Brands.Find(id);
            ViewBag.markaAd = brand_ViewModel.Brand.BrandName;
            ViewBag.markaId = brand_ViewModel.Brand.PK_BRAND_ID;
            return View(brand_ViewModel);
        }
        public ActionResult CreateComplaint(Complaint complaint)
        {
            complaint.ComplaintSwitchActive = false;
            complaint.ComplaintStatus = true;
            //  complaint.MemberId = 3;
           


            _context.Complaints.Add(complaint);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
