using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.Controllers
{
    public class LoginController : Controller
    {

        private readonly SikayetDbContext _context;


        public LoginController(SikayetDbContext context)
        {
           

            _context = context;
        }

        public IActionResult LoginScreen()
        {
            if (HttpContext.Session.GetInt32("PK_MEMBER_ID").HasValue)   //eğer login olunmuşsa tekrar login sayfasına gidilmesini engelliyor
            {
                return Redirect("/CategoryBrand/Index");
            }
            return View();
        }


        public IActionResult SignIn(string MemberMail, string MemberPassword)
        {
            var user = _context.Members.FirstOrDefault(x => x.MemberMail.Equals(MemberMail) && x.MemberPassword.Equals(MemberPassword) && x.Role.RoleId==2 );

            if(user != null)
            {

                HttpContext.Session.SetString("MEMBER_NAME", user.MemberName);
                HttpContext.Session.SetString("MEMBER_SURNAME", user.MemberLastName);
                return Redirect("/CategoryBrand/Index");

            }
            return Redirect("LoginScreen");
        }

        public IActionResult SignInAdmin(string MemberMail, string MemberPassword)
        {
            var user = _context.Members.FirstOrDefault(x => x.MemberMail.Equals(MemberMail) && x.MemberPassword.Equals(MemberPassword) && x.Role.RoleId == 1);

            if (user != null)
            {

                HttpContext.Session.SetString("MEMBER_NAME", user.MemberName);
                HttpContext.Session.SetString("MEMBER_SURNAME", user.MemberLastName);
                return Redirect("/AdminBrandPage/BrandProcess");

            }
            return Redirect("LoginScreen");
        }
        public IActionResult Register(Member member)
        {
            member.MemberStatus = true;
            member.RoleId = 1;
            _context.Members.Add(member);
            _context.SaveChanges();
            return Redirect("LoginScreen");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("LoginScreen");
                    
        }
    }
}
