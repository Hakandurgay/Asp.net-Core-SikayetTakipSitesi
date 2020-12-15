using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;

namespace SikayetTakipSitesi.ViewComponents
{
    public class BrandListViewComponent : ViewComponent
    {
        private readonly SikayetDbContext _context;

        public BrandListViewComponent(SikayetDbContext _context)
        {
            this._context = _context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Brands.Where(c =>c.BrandStatus==true));
        }
    }
}
