using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Areas.Admin.Models;

namespace WebApplication9.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        YAZODEVEntities db = new YAZODEVEntities();
        // GET: Admin/Slider
        public ActionResult Index()
        {
            var model = db.Slider.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        public ActionResult SliderEkle()
        {
            return View();
        }
        const string imageFolderPath = "/Content/slider-images/";
        public ActionResult AddSlider(SliderModel model)
        {
           
            if(ModelState.IsValid)
            {
                string fileName = string.Empty;

                if(model.Resim != null && model.Resim.ContentLength>0)
                {
                    fileName = model.Resim.FileName;
                    var path = Path.Combine(Server.MapPath("~" + imageFolderPath), fileName);
                    model.Resim.SaveAs(path);
                }
                Slider slider = new Slider();
                slider.ResimYolu = imageFolderPath+fileName;
                slider.SliderText = model.SliderText;
                db.Slider.Add(slider);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
           
        }
    }
}