using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Areas.Admin.Models;

namespace WebApplication9.Areas.Admin.Controllers
{
    public class HaberController : Controller
    {
        // GET: Admin/Haber
        YAZODEVEntities db = new YAZODEVEntities();
        public ActionResult Index()
        {
            var list = db.Haber.ToList();
            return View(list);
        }
        public ActionResult HaberEkle()
        {
            return View();
        }
        const string imageFolderPath = "/Content/haber-images/";
        public ActionResult AddHaber(HaberModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;

                if (model.HaberResim != null && model.HaberResim.ContentLength > 0)
                {
                    fileName = model.HaberResim.FileName;
                    var path = Path.Combine(Server.MapPath("~" + imageFolderPath), fileName);
                    model.HaberResim.SaveAs(path);
                }
                Haber haber = new Haber();
                haber.ResimYolu = imageFolderPath + fileName;
                haber.HaberIcerigi = model.HaberIcerigi;
                haber.HaberBasligi = model.HaberBasligi;
                haber.EklenmeTarihi = DateTime.Now;
                db.Haber.Add(haber);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model=db.Haber.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Haber model)
        {
            if(ModelState.IsValid)
            {
                db.Haber.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Haber.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var model = db.Haber.Find(id);
            db.Haber.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}