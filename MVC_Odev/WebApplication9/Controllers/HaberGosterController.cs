using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers
{
    public class HaberGosterController : Controller
    {
        YAZODEVEntities db = new YAZODEVEntities();
        // GET: HaberGoster
        public ActionResult IndexHaber()
        {
            var model = db.Haber.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        public ActionResult HaberDetay(int id)
        {
            var model = db.Haber.Find(id);
            return View(model);
           
        }
    }
}