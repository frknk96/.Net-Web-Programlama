using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers
{
    public class UyeController : Controller
    {
        YAZODEVEntities db = new YAZODEVEntities();
        // GET: Uye
        public ActionResult Index(int id)
        {
            var uye = db.Uye.Where(u => u.UyeId == id).SingleOrDefault();
            if(Convert.ToInt32(Session["uyeid"])!=uye.UyeId)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            var login = db.Uye.Where(u => u.KullaniciAdi == uye.KullaniciAdi).SingleOrDefault();
            if(login.KullaniciAdi == uye.KullaniciAdi && login.Sifre == uye.Sifre)
            {
                Session["uyeid"] = login.UyeId;
                Session["kullaniciadi"] = login.KullaniciAdi;
                Session["yetkiid"] = login.YetkiId;
                return RedirectToAction("Index", "Home");
            }
           
            else
            {
                ViewBag.Uyari = "Kullanıcı adı yada şifrenizi yanlış girdiniz";
                return View();
            }
           
        }
        public ActionResult LogOut()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Uye uye)
        {
            if(ModelState.IsValid)
            {
                uye.YetkiId = 2;
                db.Uye.Add(uye);
                db.SaveChanges();
                Session["uyeid"] = uye.UyeId;
                Session["kullaniciadi"] = uye.KullaniciAdi;
                return RedirectToAction("Index", "Home");
            }
            return View(uye);
        }
        public ActionResult Edit(int id)
        {
            var uye = db.Uye.Where(u => u.UyeId == id).SingleOrDefault();
            if(Convert.ToInt32(Session["uyeid"])!=uye.UyeId)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        [HttpPost]
        public ActionResult Edit(Uye uye,int id)
        {   
            if(ModelState.IsValid)
            {
                var uyes = db.Uye.Where(u => u.UyeId == id).SingleOrDefault();
                uyes.AdSoyad = uye.AdSoyad;
                uyes.KullaniciAdi = uye.KullaniciAdi;
                uyes.Sifre = uye.Sifre;
                uyes.Email = uye.Email;
                db.SaveChanges();
                Session["kullaniciadi"] = uye.KullaniciAdi;
                return RedirectToAction("Index", "Home", new { id = uyes.UyeId });
            }
            return View();
        }

    }
}