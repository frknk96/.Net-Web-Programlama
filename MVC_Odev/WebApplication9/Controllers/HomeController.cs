using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        YAZODEVEntities db = new YAZODEVEntities();
        public ActionResult Index()
        {
            var model = db.Haber.OrderByDescending(x=>x.ID).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Forum()
        {
            ViewBag.Message = "Forum.";

            return View();
        }
        public ActionResult Tanitim()
        {
            ViewBag.Message = "Tanitim.";

            return View();
        }
        public ActionResult TanitimFull()
        {
            ViewBag.Message = "Tanitim";
            return View();
        }
        [ChildActionOnly]
        public ActionResult _Slider()
        {
            var liste = db.Slider.ToList();
            return View(liste);
        }
        public JsonResult YorumYap(string yorum,int konuId)
        {
            var uyeid = Session["uyeid"];
            if(yorum!=null)
            {
                //return Json(true, JsonRequestBehavior.AllowGet);
                db.Yorum.Add(new Yorum { UyeId = Convert.ToInt32(uyeid), ID = konuId, YorumIcerik = yorum, YorumTarihi = DateTime.Now });
                db.SaveChanges();
            }
            
            return Json(false,JsonRequestBehavior.AllowGet);
        }
    }
}