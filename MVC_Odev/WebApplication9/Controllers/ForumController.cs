using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult IndexForum()
        {
            return View();
        }
    }
}