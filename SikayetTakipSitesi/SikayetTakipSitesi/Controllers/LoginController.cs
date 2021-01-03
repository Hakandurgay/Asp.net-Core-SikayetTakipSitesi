using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SikayetTakipSitesi.Data;
using SikayetTakipSitesi.Models;

namespace SikayetTakipSitesi.Controllers
{

    public class LoginController : Controller
    {

        private readonly SikayetDbContext _context;
        private readonly IStringLocalizer<LoginController> _localizer;
       
        public LoginController(SikayetDbContext context, IStringLocalizer<LoginController> localizer, IStringLocalizer<SharedResources> sharedLocalizer)
        {
            _context = context;
            _localizer = localizer;
       
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult LoginScreen()
        {
            ViewData["Message"] = _localizer.GetString("Message");

            if (HttpContext.Session.GetInt32("MEMBER_ID").HasValue)   //eğer login olunmuşsa tekrar login sayfasına gidilmesini engelliyor
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public IActionResult SignIn(Member member)
        {
            member = _context.Members.FirstOrDefault(x => x.MemberMail.Equals(member.MemberMail) && x.MemberPassword.Equals(member.MemberPassword) && x.Role.RoleId==2 );

            if(member != null)
            {
                SaveUserDataWithSession(member);
                return Redirect("/Home/Index");

            }
            return Redirect("LoginScreen");
        }

        public IActionResult SignInAdmin(Member member)
        {
            member = _context.Members.FirstOrDefault(x => x.MemberMail.Equals(member.MemberMail) && x.MemberPassword.Equals(member.MemberPassword) && x.Role.RoleId == 1);

            if (member != null)
            {

                SaveUserDataWithSession(member);
                return Redirect("/AdminBrandPage/BrandProcess");

            }
            return Redirect("LoginScreen");
        }
        public IActionResult Register(Member member)
        {
            member.MemberStatus = true;
            member.RoleId = 2;
            _context.Members.Add(member);
            _context.SaveChanges();
            return Redirect("LoginScreen");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("LoginScreen");
                    
        }

        private void SaveUserDataWithSession(Member member)
        {
            HttpContext.Session.SetInt32("MEMBER_ID", member.PK_MEMBER_ID);
            HttpContext.Session.SetString("MEMBER_NAME", member.MemberName);
            HttpContext.Session.SetString("MEMBER_SURNAME", member.MemberLastName);
        }

    }
}
