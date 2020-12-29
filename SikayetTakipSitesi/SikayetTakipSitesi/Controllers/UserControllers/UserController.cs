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

namespace SikayetTakipSitesi.Controllers.UserControllers
{
    [UserFilter]
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
            TempData["userId"] = Convert.ToInt32(id);

            return View( await ListComplaints(id));
        }


        private async  Task<UserViewModel> ListComplaints(int id)
        {
            ViewBag.kontrol = "sikayet";
            Member member = _context.Members.Find(id);
            ViewBag.username = member.MemberName;
            ViewBag.userLastname = member.MemberLastName;
            ViewBag.userid = member.PK_MEMBER_ID;

            userModelView.Complaints = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(x => x.FK_MEMBER_ID.PK_MEMBER_ID == id && x.ComplaintStatus == true && x.ComplaintSwitchActive == true).ToListAsync();

            return userModelView;
        }
        private async Task<UserViewModel> ListComments(int id)
        {

            ViewBag.kontrol = "yorum";
            Member member = _context.Members.Find(id);
            ViewBag.username = member.MemberName;
            ViewBag.userLastname = member.MemberLastName;

            userModelView.Comments = await _context.Comments.Include(x => x.Complaint).Where(x => x.Member.PK_MEMBER_ID == id && x.CommentStatus == true && x.CommentSwitchActive == true).Include(x => x.Complaint.FK_BRAND_ID).ToListAsync();
            return userModelView;
        }



        [HttpGet("{type}")]
        public async Task<IActionResult> Index(string type)
        {
            int id = Convert.ToInt32( TempData["userId"]);
            TempData["userId"] = Convert.ToInt32(id);
            if (type=="1") //type bir ise şikayet, iki ise yorum
                return  View(await ListComplaints(id));
               
            return View(await ListComments(id));
            
        }
    }
}
