//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_Ly_Nha_Hang.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CALAMVIEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CALAMVIEC()
        {
            this.PHANCONG = new HashSet<PHANCONG>();
        }
    
        public int IDCaLamViec { get; set; }
        public string TenCaLam { get; set; }
        public Nullable<System.TimeSpan> GioBD { get; set; }
        public Nullable<System.TimeSpan> GioKT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONG> PHANCONG { get; set; }
    }
}
