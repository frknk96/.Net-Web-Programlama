using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Areas.Admin.Models
{
    public class HaberModel
    {
        public int ID { get; set; }
        public string HaberBasligi { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public string HaberIcerigi { get; set; }
        
        public string ResimYolu { get; set; }
        public HttpPostedFileBase HaberResim { get; set; }
    }
}