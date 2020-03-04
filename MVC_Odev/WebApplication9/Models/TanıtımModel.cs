using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class TanıtımModel
    {
        public int ID { get; set; }
        public string KonuAdi { get; set; }
        public Nullable<System.DateTime> KonuTarihi { get; set; }
        public string KonuIcerik { get; set; }
        public Nullable<int> FKKategoriID { get; set; }
       
        public string ResimYolu { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual Yorum Yorum { get; set; }
        public HttpPostedFileBase TanıtımResim { get; set; }
    }
}