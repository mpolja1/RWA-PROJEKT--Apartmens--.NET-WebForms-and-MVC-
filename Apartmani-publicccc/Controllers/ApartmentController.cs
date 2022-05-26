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
        public ActionResult Index()
        {

            return View(repo.GetApartments());
        }

        public ActionResult Details(int? id)
        {
           Apartment apartment = repo.GetApartmentById((int)id);
            
            return View(apartment);
        }
    }
}