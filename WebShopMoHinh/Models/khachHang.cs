//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShopMoHinh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class khachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachHang()
        {
            this.Orderproes = new HashSet<Orderpro>();
        }
    
        public int khID { get; set; }
        public string Name { get; set; }
        public string TaxCode { get; set; }
        public string SDT { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderpro> Orderproes { get; set; }
    }
}
