using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    
    public class HomeController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);

            //ViewBag.Iletisim = db.Iletisim.SingleOrDefault();

            //ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            return View();
        }
        public ActionResult SliderPartial()
        {
            List<Slider> slideIdList = db.Slider.ToList().OrderByDescending(x => x.SliderId).ToList();
            return View(slideIdList);
        }
        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }
        public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.SingleOrDefault());
        }
        public ActionResult Hizmetlerimiz()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }
        public ActionResult Iletisim()
        {
            return View(db.Iletisim.SingleOrDefault());
        }
        public ActionResult FooterPartial()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);

            ViewBag.Iletisim = db.Iletisim.FirstOrDefault();

            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);

            return PartialView();
        }
    }
}