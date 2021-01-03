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
using X.PagedList;

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

        [HttpGet]
        public async Task<IActionResult> Index(int id,int sayfa=1)
        {
            Brand brand = _context.Brands.Find(id);
            ViewBag.brandName = brand.BrandName;
            ViewBag.BrandPhoto = brand.BrandPhoto;
              //  -->bunun eklenmesi lazım buraya member controlleri oluşturunca bak. memeber name
            IPagedList<Complaint> complaints = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(y => y.FK_BRAND_ID.BrandStatus == true && y.ComplaintStatus == true && y.ComplaintSwitchActive==true && y.FK_BRAND_ID.PK_BRAND_ID == id).ToPagedListAsync(sayfa,5);
            return View(complaints);
        }
    }
}
