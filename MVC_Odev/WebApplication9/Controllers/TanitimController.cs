using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class TanitimController : Controller
    {
        // GET: Tanitim
        YAZODEVEntities db = new YAZODEVEntities();
        public ActionResult IndexTanitim()
        {
           ViewBag.Kategoriler=new SelectList(db.Kategori.ToList(),"ID","KategoriAd");
           var model = db.Tanıtım.OrderByDescending(x => x.ID).ToList();
           return View(model);
        }
        [HttpPost]
        public ActionResult IndexTanitim(Models.KonuAramaModel arama)
        {
            ViewBag.Kategoriler = new SelectList(db.Kategori.ToList(), "ID", "KategoriAd");
            var sorgu = db.Tanıtım.AsQueryable();
            if (!string.IsNullOrEmpty(arama.konuAdi))
            {
                sorgu = sorgu.Where(x => x.KonuAdi.Contains(arama.konuAdi));
            }
            if(arama.Kategoriler>0)
            {
                sorgu = sorgu.Where(x => x.FKKategoriID == arama.Kategoriler);
            }
            var model = sorgu.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
       
        public ActionResult TanitimFull(int id)
        {
            var model = db.Tanıtım.Find();
            return View(model);
        }
        public ActionResult TanitimEkle()
        {
            ViewBag.FKKategoriID = new SelectList(db.Kategori.ToList(), "ID", "KategoriAd");
            return View();
        }
        [HttpPost]
        public ActionResult TanitimEkle(Tanıtım model)
        {
            
            model.KonuTarihi = DateTime.Now;
            if (@ModelState.IsValid)
            {
                db.Tanıtım.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("IndexTanitim");
        }
        const string imageFolderPath = "/Content/tanıtım-images/";
        public ActionResult AddTanitim(TanıtımModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;

                if (model.TanıtımResim != null && model.TanıtımResim.ContentLength > 0)
                {
                    fileName = model.TanıtımResim.FileName;
                    var path = Path.Combine(Server.MapPath("~" + imageFolderPath), fileName);
                    model.TanıtımResim.SaveAs(path);
                }
                Tanıtım tanıtım = new Tanıtım();
                tanıtım.ResimYolu = imageFolderPath + fileName;
                tanıtım.KonuIcerik = model.KonuIcerik;
                tanıtım.KonuAdi = model.KonuAdi;
                tanıtım.KonuTarihi = DateTime.Now;
                tanıtım.FKKategoriID = model.FKKategoriID;
                db.Tanıtım.Add(tanıtım);
                db.SaveChanges();
            }
            return RedirectToAction("IndexTanitim");
        }
        public ActionResult Detay(int id)
        {
            var model = db.Tanıtım.Find(id);
            return View(model);
        }
      
    }
}