using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;

namespace SikayetTakipSitesi.ViewComponents
{
    public class BrandDetailViewComponent: ViewComponent
    {
        private readonly SikayetDbContext _context;

        public BrandDetailViewComponent(SikayetDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Complaints.Where(c => c.ComplaintStatus == true));
        }
    }
}
