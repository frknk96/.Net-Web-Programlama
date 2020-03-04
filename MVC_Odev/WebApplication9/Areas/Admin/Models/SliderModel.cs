using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Areas.Admin.Models
{
    public class SliderModel
    {
        public int ID { get; set; }
        public string SliderText { get; set; }
        public string ResimYolu { get; set; }
        public HttpPostedFileBase Resim { get; set; }
    }
}