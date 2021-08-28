using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

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
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
        }
        public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.SingleOrDefault());
        }
        public ActionResult Hizmetlerimiz()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
        }
        public ActionResult Iletisim()
        {
            return View(db.Iletisim.SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "kurumsalweb04@gmail.com";//gmail adres yazılacak.
                WebMail.Password = "KurumsalWeb04";//gmailin şifresi girilecek.
                WebMail.SmtpPort = 587;
                WebMail.Send("kurumsalweb04@gmail.com", konu, email + "-" + mesaj);
                ViewBag.Uyari = "Mesajınız başarı ile gönderildi.";
            }
            else
            {
                ViewBag.Uyari = "Hata oluştu tekrar deneyiniz";
            }
            return View();
        }
        public ActionResult Blog(int Sayfa = 1)
        {
            return View(db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa, 5));
        }
        public ActionResult BlogDetay(int id)
        {
            var b = db.Blog.Include("Kategori").Where(x => x.BlogId == id).SingleOrDefault();
            return View(b);
        }
        public JsonResult YorumYap(string adsoyad, string eposta, string icerik, int blogid)
        {
            if (icerik == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.Yorum.Add(new Yorum
            {
                AdSoyad = adsoyad,
                Eposta = eposta,
                Icerik = icerik,
                BlogId = blogid
            });
            db.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BlogKategoriPartial()
        {
            return PartialView(db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd));
        }
        public ActionResult BlogKayitPartial()
        {
            return PartialView(db.Blog.ToList().OrderByDescending(x => x.BlogId));
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