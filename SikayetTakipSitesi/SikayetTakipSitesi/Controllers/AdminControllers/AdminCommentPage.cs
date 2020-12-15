using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.Controllers.AdminControllers
{
    public class AdminCommentPage : Controller
    {

        private readonly SikayetDbContext _context;

        public AdminCommentPage(SikayetDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ComfirmCommet()
        {
            //  (_context.Comments.Select(z => z.MemberId))

            List<Comment> comments = _context.Comments.Include(x => x.Member).
                                                           Include(y => y.Complaint).
                                                           Include(y => y.Complaint.FK_BRAND_ID).
                                                           Where(b => b.CommentStatus == true && b.CommentSwitchActive == false).ToList(); //onaylanammış yorumlar gösteriliyor


            return View(comments);
        }
        [HttpPost]
        public IActionResult ComfirmCommet(int id)
        {
            List<Comment> comments = _context.Comments.Include(x => x.Member).
                                                           Include(y => y.Complaint).
                                                           Include(y => y.Complaint.FK_BRAND_ID).
                                                           Where(b => b.CommentStatus == true && b.CommentSwitchActive == false).Where(z => z.Complaint.FK_BRAND_ID.PK_BRAND_ID == id).ToList(); //onaylanammış yorumlar gösteriliyor
            return View(comments);
        }

        public IActionResult ComfirmComment_ConfirmButton(int id)
        {
            //  (_context.Comments.Select(z => z.MemberId))

            var comment = _context.Comments.Find(id);
            comment.CommentSwitchActive = true;
            _context.Comments.Update(comment);
            _context.SaveChanges();

            return RedirectToAction("ComfirmCommet");
        }
        public IActionResult ComfirmComment_RejectButton(int id)
        {
            //  (_context.Comments.Select(z => z.MemberId))

            var comment = _context.Comments.Find(id);
            comment.CommentStatus = false;
            _context.Comments.Update(comment);
            _context.SaveChanges();

            return RedirectToAction("ComfirmCommet");
        }


    }
}
