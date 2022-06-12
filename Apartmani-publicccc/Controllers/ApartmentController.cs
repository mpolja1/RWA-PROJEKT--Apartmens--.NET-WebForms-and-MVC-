using Apartmani_publicccc.Models;
using DAL;
using DAL.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            ViewBag.city = new SelectList(repo.GetCities(),"Id", "Name");

            var model = repo.SearchAparments(searchModel);

            return View(model);
        }


        public ActionResult Details(int id)
        {

            var model = new ApartmentDetailsViewModel
            {
                apartment = repo.GetApartmentById(id),
                Tags = repo.GetTagsByApartment(id),
                Images = repo.GetApartmentPictures(id)

            };

            return View(model);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult probinjo()
        {

            var model = repo.GetApartments();

            return View(model);
        }


    }
}