using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly SikayetDbContext _context;

        public CategoryMenuViewComponent(SikayetDbContext _context)
        {
            this._context = _context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Categories.Where(c => c.CategoryStatus == true));
        }
    }
}

