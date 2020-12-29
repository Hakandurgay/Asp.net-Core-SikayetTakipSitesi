using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;
using SikayetTakipSitesi.ViewModels;

namespace SikayetTakipSitesi.Controllers.UserControllers
{
    public class UserController : Controller
    {
        private readonly SikayetDbContext _context;

        public UserController(SikayetDbContext context)
        {
            this._context = context;
        }

        UserViewModel userModelView = new UserViewModel();
       [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.kontrol = 0;
            Member member = _context.Members.Find(id);
            ViewBag.username = member.MemberName;
            ViewBag.userLastname = member.MemberLastName;
            ViewBag.userid = member.PK_MEMBER_ID;

            userModelView.Complaints = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(x => x.FK_MEMBER_ID.PK_MEMBER_ID == id && x.ComplaintStatus==true && x.ComplaintSwitchActive==true).ToListAsync();

            return View(userModelView);
        }

        [HttpPost]
        public async Task<IActionResult> Index1(int id)
        {
            ViewBag.kontrol = 0;
            Member member = _context.Members.Find(id);
            ViewBag.username = member.MemberName;
            ViewBag.userLastname = member.MemberLastName;
            ViewBag.userid = member.PK_MEMBER_ID;
            userModelView.Comments = await _context.Comments.Include(x => x.Complaint).Where(x => x.Member.PK_MEMBER_ID == id && x.CommentStatus == true && x.CommentSwitchActive == true).Include(x=>x.Complaint.FK_BRAND_ID).ToListAsync();
            return View(userModelView);
        }

    }
}
