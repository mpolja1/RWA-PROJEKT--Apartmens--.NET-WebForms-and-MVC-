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
using System.IO;
using Apartmani_publicccc.Models.CustomAttributes;

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
            filter.Values.Add("adult", searchModel.Adult.ToString());
            filter.Values.Add("children", searchModel.Children.ToString());


            Response.Cookies.Add(filter);

            

            var model = repo.SearchAparments(searchModel);
           

            return View(model);
        }


        [HttpGet]
        //[IsAuthorized]

        public JsonResult Filter(ApartmenSearchModel search)
        {
            var model=repo.GetApartments();
            if (search!= null)
            {
                model = repo.SearchAparments(search);
            }

           
   
            return Json(model, JsonRequestBehavior.AllowGet);
        }
   

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

            if (Session["UserId"]==null)
            {
                if (!this.IsCaptchaValid(""))
                {
                    ViewBag.error = "Neuspjesno";

                    return Redirect(Request.UrlReferrer.ToString());

                }
                else
                {
                    repo.SaveApartmentReservation(reservation);
                    ViewBag.apartman = repo.GetApartmentById(reservation.ApartmentId);
                    return Redirect("prboinjo");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    repo.SaveApartmentReservation(reservation);
                    ViewBag.apartman = repo.GetApartmentById(reservation.ApartmentId);
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            
            return Json(reservation,JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }
        
        public ActionResult Picture(string path)
        {
            if (path == null || string.IsNullOrEmpty(path))
                return Content(content: "File missing");

            var javnoRoot = Server.MapPath("~");
            var adminRoot = Path.Combine(javnoRoot, "../Apartmani/Images");
            var picturePath = Path.Combine(adminRoot, path);
            string mimeType = MimeMapping.GetMimeMapping(picturePath);
            return new FilePathResult(picturePath, mimeType);
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
         

            var redirectUrl = new UrlHelper(Request.RequestContext).Action( "Index","Apartment",new {apartmentReview.ApartmentId});
            return Json(new { Url = redirectUrl });

            
        }

    }
}