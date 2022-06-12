using DAL;
using DAL.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Apartmani_publicccc.Controllers
{
 
    public class AccountController : Controller
    {
        public Irepo repo = RepoFactory.GetRepository();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LogIn()
        {
            
            return View();
        }
      
        [HttpPost]
        public ActionResult LogIn(User user)
        {
           
            if (!ModelState.IsValid)
            {
                User authUser = repo.AuthUser(user.Email, user.PasswordHash);
                if (authUser != null)
                {
                    
                    Session["username"] = authUser.UserName;
                    return RedirectToAction("Index", controllerName: "Apartment");
                }
                else
                {
                    ViewBag.Notification = "Wrong password or email";
                }
            }

            return View();
        }

        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                repo.SaveUser(user);
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction(actionName:"Index",controllerName: "Apartment");
        }
        public ActionResult Language(string language)
        {
            if (!string.IsNullOrEmpty(language))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
            HttpCookie cookie = new HttpCookie("Languages");
            cookie.Value = language;
            Response.Cookies.Add(cookie);

            return RedirectToAction("index", "Apartment");
        }
    }
}