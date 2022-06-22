using Apartmani_publicccc.Models;
using DAL;
using DAL.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;


namespace Apartmani_publicccc.Controllers
{
   
    public class ApartmentController : Controller
    {

        Irepo repo = RepoFactory.GetRepository();
        public ActionResult Index(ApartmenSearchModel searchModel)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {new SelectListItem{Text="Price-Najveca/Najmanja",Value="Desc"},
               new SelectListItem{Text="Price-Najmanja/Najveca",Value="Asc"} };
            ViewBag.listToSort = list;

            ViewBag.city = new SelectList(repo.GetCities(), "Id", "Name");

            HttpCookie filter = new HttpCookie("filter");

            filter.Values.Add("room", searchModel.Room.ToString());
            filter.Values.Add("adult", searchModel.Room.ToString());
            filter.Values.Add("children", searchModel.Children.ToString());


            //filter.Expires.AddMinutes(1);

            Response.Cookies.Add(filter);

            var model = repo.SearchAparments(searchModel);

            return View(model);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new ApartmentDetailsViewModel
            {
                apartment = repo.GetApartmentById(id),
                Tags = repo.GetTagsByApartment(id),
                Images = repo.GetApartmentPictures(id),

            };


            if (Session["UserId"] != null)
            {
                int userId = int.Parse((string)Session["Userid"]);
                model.User = repo.GetUserById(userId);
            }



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation(ApartmentReservation reservation)
        {



            if (!this.IsCaptchaValid(""))
            {
                ViewBag.error = "Neuspjesno";

                return Redirect(Request.UrlReferrer.ToString());

            }
            else
            {
                ViewBag.uspjesno = "Rezervacija uspjesno spremljena";
                repo.SaveApartmentReservation(reservation);
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult UserReservation(int id)
        {
            var reservation = repo.GetUserReservation(id);
            List<Apartment> apartmani = new List<Apartment>();
            foreach (var item in reservation)
            {
               apartmani.Add(repo.GetApartmentById(item.ApartmentId));
               
            }
            


            return View(apartmani);
        }

        [HttpGet]
        public ActionResult Review(int id)
        {
            Session["apartmenId"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult Review(ApartmentReview apartmentReview)
        {
            
            repo.SetApartmentReview(apartmentReview);
            ViewBag.msg = "Uspjesna recenzija";
           
            return View();
        }

    }
}