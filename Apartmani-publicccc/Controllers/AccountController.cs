﻿
using DAL;
using DAL.DAL;
using DAL.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Apartmani_publicccc.Controllers
{

    public class AccountController : Controller
    {
        public Irepo repo = RepoFactory.GetRepository();
       
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult LogIn(User user)
        {

            var authuser = repo.AuthUser(user.Email, user.PasswordHash);
            if (authuser != null)
            {
                Session["username"] = authuser.UserName;
                Session["UserId"] = authuser.Id;
                return RedirectToAction("Index", "Apartment");
            }
                else
                {
                    ViewBag.Notification = DAL.Resources.Language.WrongPasswordEmail;
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
                TempData["AlertMsg"] = "Uspjesna registracija";
                return RedirectToAction("Index", "Apartment");
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