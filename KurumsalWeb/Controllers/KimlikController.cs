using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class KimlikController : Controller
    {
        // GET: Kimlik
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kimlik/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kimlik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kimlik/Create
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

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kimlik/Edit/5
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

        // GET: Kimlik/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kimlik/Delete/5
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
