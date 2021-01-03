using SikayetTakipSitesi.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.User
{
    class User_DAL
    {


        private async Task<UserViewModel> ListComplaints(int id, int sayfa)
        {
            ViewBag.kontrol = "sikayet";
            Member member = _context.Members.Find(id);
            ViewBag.username = member.MemberName;
            ViewBag.userLastname = member.MemberLastName;
            ViewBag.userid = member.PK_MEMBER_ID;

            userModelView.Complaints = await _context.Complaints.Include(x => x.FK_BRAND_ID).Where(x => x.FK_MEMBER_ID.PK_MEMBER_ID == id && x.ComplaintStatus == true && x.ComplaintSwitchActive == true).ToPagedListAsync(sayfa, 6);

            return userModelView;
        }
        private async Task<UserViewModel> ListComments(int id, int sayfa)
        {

            ViewBag.kontrol = "yorum";
            Member member = _context.Members.Find(id);
            ViewBag.username = member.MemberName;
            ViewBag.userLastname = member.MemberLastName;

            userModelView.Comments = await _context.Comments.Include(x => x.Complaint).Where(x => x.Member.PK_MEMBER_ID == id && x.CommentStatus == true && x.CommentSwitchActive == true).Include(x => x.Complaint.FK_BRAND_ID).ToPagedListAsync(sayfa, 6);
            return userModelView;
        }


    }
}
