//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication9
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tanıtım
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tanıtım()
        {
            this.Yorum1 = new HashSet<Yorum>();
        }
    
        public int ID { get; set; }
        public string KonuAdi { get; set; }
        public Nullable<System.DateTime> KonuTarihi { get; set; }
        public string KonuIcerik { get; set; }
        public Nullable<int> FKKategoriID { get; set; }
        public byte[] KonuFoto { get; set; }
        public string ResimYolu { get; set; }
        public Nullable<int> UyeId { get; set; }
        public Nullable<int> Okunma { get; set; }
    
        public virtual Kategori Kategori { get; set; }
        public virtual Yorum Yorum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum1 { get; set; }
    }
}
