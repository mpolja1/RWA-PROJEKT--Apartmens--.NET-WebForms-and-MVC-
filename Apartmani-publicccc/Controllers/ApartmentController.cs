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
        // GET: Apartment
        Irepo repo = RepoFactory.GetRepository();
        public ActionResult Index(ApartmenSearchModel searchModel, string sort)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {new SelectListItem{Text="Price-Najveca/Najmanja",Value="Desc"},
               new SelectListItem{Text="Price-Najmanja/Najveca",Value="Asc"} };
            ViewBag.listToSort = list;

            var model = repo.SearchAparments(searchModel);
   
            return View(model);
        }


        public ActionResult Details(int? id)
        {
            Apartment apartment = repo.GetApartmentById((int)id);

            return View(apartment);
        }

    }
}