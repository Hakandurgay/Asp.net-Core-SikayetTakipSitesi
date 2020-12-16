using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;

namespace SikayetTakipSitesi.Controllers.AdminControllers
{
    public class AdminComplaintPage : Controller
    {
        private readonly SikayetDbContext _context;

        public AdminComplaintPage(SikayetDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            AdminComplaintViewModel viewModel = new AdminComplaintViewModel();

            viewModel.Complaints = _context.Complaints.Include(x => x.FK_BRAND_ID ).
                                                        Include(y => y.FK_MEMBER_ID ).                                                
                                                        Where(b => b.ComplaintStatus == true && b.ComplaintSwitchActive == false).ToList(); //onaylanammış yorumlar gösteriliyor
            viewModel.Brands = _context.Brands.Where(c => c.BrandStatus == true).ToList();

            return View(viewModel);
        
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            AdminComplaintViewModel viewModel = new AdminComplaintViewModel();

            viewModel.Complaints = _context.Complaints.Include(x => x.FK_BRAND_ID).
                                                        Include(y => y.FK_MEMBER_ID).
                                                        Where(b => b.ComplaintStatus == true && b.ComplaintSwitchActive == false).Where(x=>x.FK_BRAND_ID.PK_BRAND_ID==id).ToList(); //onaylanammış yorumlar gösteriliyor

            viewModel.Brands = _context.Brands.Where(c => c.BrandStatus == true).ToList();

            return View(viewModel);

        }
        public IActionResult ConfirmComplaint(int id)
        {
            //  (_context.Comments.Select(z => z.MemberId))

            var complaint = _context.Complaints.Find(id);
            complaint.ComplaintSwitchActive = true;
            _context.Complaints.Update(complaint);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult RejectComplaint(int id)
        {
     
            var complaint = _context.Complaints.Find(id);
            complaint.ComplaintStatus = false;
            _context.Complaints.Update(complaint);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
