using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.Controllers
{
    public class CategoryBrandController : Controller
    {
        private readonly SikayetDbContext _context;

        public CategoryBrandController(SikayetDbContext context)
        {
            _context = context;
        }

        // GET: CategoryBrand
        public async Task<IActionResult> Index()
        {
            var sikayetDbContext = _context.CategoryBrands.Include(c => c.Brand).Include(c => c.Category);
            return View(await sikayetDbContext.ToListAsync());
        }

        // GET: CategoryBrand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryBrand = await _context.CategoryBrands
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoryBrand == null)
            {
                return NotFound();
            }

            return View(categoryBrand);
        }

        // GET: CategoryBrand/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "PK_BRAND_ID", "PK_BRAND_ID");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "PK_CATEGORY_ID", "PK_CATEGORY_ID");
            return View();
        }

        // POST: CategoryBrand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CategoryId,BrandId")] CategoryBrand categoryBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "PK_BRAND_ID", "PK_BRAND_ID", categoryBrand.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "PK_CATEGORY_ID", "PK_CATEGORY_ID", categoryBrand.CategoryId);
            return View(categoryBrand);
        }

        // GET: CategoryBrand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryBrand = await _context.CategoryBrands.FindAsync(id);
            if (categoryBrand == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "PK_BRAND_ID", "PK_BRAND_ID", categoryBrand.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "PK_CATEGORY_ID", "PK_CATEGORY_ID", categoryBrand.CategoryId);
            return View(categoryBrand);
        }

        // POST: CategoryBrand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CategoryId,BrandId")] CategoryBrand categoryBrand)
        {
            if (id != categoryBrand.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryBrandExists(categoryBrand.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "PK_BRAND_ID", "PK_BRAND_ID", categoryBrand.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "PK_CATEGORY_ID", "PK_CATEGORY_ID", categoryBrand.CategoryId);
            return View(categoryBrand);
        }

        // GET: CategoryBrand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryBrand = await _context.CategoryBrands
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoryBrand == null)
            {
                return NotFound();
            }

            return View(categoryBrand);
        }

        // POST: CategoryBrand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryBrand = await _context.CategoryBrands.FindAsync(id);
            _context.CategoryBrands.Remove(categoryBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryBrandExists(int id)
        {
            return _context.CategoryBrands.Any(e => e.ID == id);
        }
    }
}
