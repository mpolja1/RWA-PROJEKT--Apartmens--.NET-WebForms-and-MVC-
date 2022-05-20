using DAL;
using DAL.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apartmani_public.Controllers
{
    public class ApartmaniController : Controller
    {
        // GET: Apartmani
        Irepo repo = RepoFactory.GetRepository();
        public ActionResult Index()
        {
            List<Apartment> apartments = repo.GetApartments();
            List<TaggedApartment> taggedApartments = (List<TaggedApartment>)repo.GetTagsByApartment(1);
            return View(apartments);
        }

        // GET: Apartmani/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Apartmani/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartmani/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apartmani/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Apartmani/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apartmani/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Apartmani/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
