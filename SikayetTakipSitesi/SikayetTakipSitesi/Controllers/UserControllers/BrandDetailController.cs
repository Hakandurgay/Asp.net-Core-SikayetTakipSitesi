using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Filters;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;

namespace SikayetTakipSitesi.Controllers
{
    [UserFilter]
    public class BrandDetailController : Controller
    {
        private readonly SikayetDbContext _context;

        public BrandDetailController(SikayetDbContext context)
        {
            this._context = context;
        }

        BrandDetailModelView brandDetailModelView = new BrandDetailModelView();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Complaint> complaints = await _context.Complaints.Where(c => c.ComplaintStatus == true && c.ComplaintSwitchActive==true).ToListAsync();
            return View(complaints);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            Brand brand = _context.Brands.Find(id);
            ViewBag.brandName = brand.BrandName;
          //  ViewBag.memberName = brandDetailModelView.Member.MemberName;  -->bunun eklenmesi lazım buraya member controlleri oluşturunca bak.
            List<Complaint> complaints = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(y => y.FK_BRAND_ID.BrandStatus == true && y.ComplaintStatus == true && y.FK_BRAND_ID.PK_BRAND_ID == id).ToListAsync();
            return View(complaints);
        }
    }
}
