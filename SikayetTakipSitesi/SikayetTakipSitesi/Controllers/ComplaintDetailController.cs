using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewComponents;
using SikayetTakipSitesi.ViewModels;

namespace SikayetTakipSitesi.Controllers
{
    public class ComplaintDetailController : Controller
    {
        private readonly SikayetDbContext _context;

        public ComplaintDetailController(SikayetDbContext context)
        {
            this._context = context;
        }

        ComplaintDetailModelView complaintDetailModelView = new ComplaintDetailModelView();
        BrandDetailModelView brandDetailModelView = new BrandDetailModelView();
        CommentModelView commentModelView = new CommentModelView();

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            var Complaintmemberid = await _context.Complaints.Include(x => x.FK_MEMBER_ID).Where(y => y.PK_COMPLAINT_ID == id && y.ComplaintStatus == true && y.ComplaintSwitchActive == true).ToListAsync();
            var brandid = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(y => y.PK_COMPLAINT_ID == id && y.ComplaintStatus == true && y.ComplaintSwitchActive == true).ToListAsync();

            complaintDetailModelView.Member = _context.Members.Find(Complaintmemberid[0].MemberId);
            brandDetailModelView.Brand = _context.Brands.Find(brandid[0].BrandId);
            commentModelView.Complaint = _context.Complaints.Find(id);

            ViewBag.brandName = brandDetailModelView.Brand.BrandName;
            ViewBag.userName = complaintDetailModelView.Member.MemberName;
            ViewBag.userLastName = complaintDetailModelView.Member.MemberLastName;
            ViewBag.userPhoto = complaintDetailModelView.Member.MemberPhoto;
            ViewBag.complaintTitle = commentModelView.Complaint.ComplaintTitle;
            ViewBag.complaintContent = commentModelView.Complaint.ComplaintContent;

            commentModelView.comments = await _context.Comments.Include(x => x.Complaint).Where(y => y.ComplaintId == id).Include(x => x.Member).Where(y => y.CommentStatus == true && y.CommentSwitchActive == true).ToListAsync();


            return View(commentModelView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CommentSwitchActive = false;
                comment.CommentStatus = true;
                comment.MemberId = 2;

                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(comment);
        }

        /*    [HttpGet]
            public async Task<IActionResult> Create()
            {

                return 
            }*/
    }
}

