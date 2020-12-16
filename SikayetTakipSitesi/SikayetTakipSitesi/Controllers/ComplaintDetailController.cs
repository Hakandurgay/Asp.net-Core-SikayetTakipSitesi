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
        CommentModelView commentModelView;
  
        public ComplaintDetailController(SikayetDbContext context)
        {
            this._context = context;
            commentModelView = new CommentModelView();
           
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            //id li şikayetin member, complaint  ve brand bilgilerini getiriyor
            commentModelView.Complaint = await _context.Complaints.Include(x => x.FK_MEMBER_ID).
                                                                   Include(x=>x.FK_BRAND_ID).
                                                                   Where(y => y.PK_COMPLAINT_ID == id && y.ComplaintStatus == true && y.ComplaintSwitchActive == true).FirstOrDefaultAsync() ;
            commentModelView.Comments =await _context.Comments.Include(x=>x.Member).
                                                          Where(a => a.Complaint.PK_COMPLAINT_ID == id && a.Complaint.ComplaintSwitchActive==true &&a.Complaint.ComplaintStatus==true ).
                                                          Where(a=>a.CommentSwitchActive==true && a.CommentStatus==true).ToListAsync(); //complaint id si id olanların yorumlarını left join yaparak getiriyor

            return View(commentModelView);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
                comment.CommentSwitchActive = false;
                comment.CommentStatus = true;
                comment.MemberId = 2;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = comment.ComplaintId });
            
        }

    }
}

