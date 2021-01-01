using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Filters;
using SikayetTakipSitesi.Models;
using X.PagedList;

namespace SikayetTakipSitesi.Controllers.AdminControllers
{
    [UserFilter]
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
        public IActionResult ComfirmCommet(int sayfa = 1)
        {
            //  (_context.Comments.Select(z => z.MemberId))

            var degerler = _context.Comments.Include(x => x.Member).
                                                           Include(y => y.Complaint).
                                                           Include(y => y.Complaint.FK_BRAND_ID).
                                                           Where(b => b.CommentStatus == true && b.CommentSwitchActive == false).ToList().ToPagedList(sayfa, 8);  //onaylanammış yorumlar gösteriliyor



            return View(degerler);
        }
        [HttpPost]
        public IActionResult ComfirmCommet(int id, int sayfa = 1)
        {
            var degerler = _context.Comments.Include(x => x.Member).
                                                           Include(y => y.Complaint).
                                                           Include(y => y.Complaint.FK_BRAND_ID).
                                                           Where(b => b.CommentStatus == true && b.CommentSwitchActive == false).Where(z => z.Complaint.FK_BRAND_ID.PK_BRAND_ID == id).ToList().ToPagedList(sayfa,8); //onaylanammış yorumlar gösteriliyor
            return View(degerler);
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
