using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class KimlikController : Controller
    {
        // GET: Kimlik
        KurumsalDBContext db = new KurumsalDBContext();
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] //güvenlik önlemi olarak urllerin gönderimesinde güvenlik açıklarına karşı bir güvenlik önlemi alıyor.
        [ValidateInput(false)]
        public ActionResult Edit(int id, Kimlik kimlik,HttpPostedFileBase logoURL)
        {
            if (ModelState.IsValid)
            {
                var kimlik1 = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
                if (logoURL!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(kimlik1.logoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(kimlik1.logoURL));
                    }
                    WebImage img = new WebImage(logoURL.InputStream);
                    FileInfo imginfo = new FileInfo(logoURL.FileName);

                    string logoname = logoURL.FileName +imginfo.Extension;
                    img.Resize(300,200);
                    img.Save("~/Uploads/Kimlik/" + logoname);

                    kimlik1.logoURL = "/Uploads/Kimlik/" + logoname;
                }
                kimlik1.Title = kimlik.Title;
                kimlik1.Keywords = kimlik.Keywords;
                kimlik1.Description = kimlik.Description;
                kimlik1.Unvan = kimlik.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kimlik);
        }
    }
}
