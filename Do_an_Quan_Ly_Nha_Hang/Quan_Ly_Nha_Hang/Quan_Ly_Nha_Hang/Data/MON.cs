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
    
    public partial class MON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MON()
        {
            this.CHITIETHD = new HashSet<CHITIETHD>();
        }
    
        public int IDMon { get; set; }
        public string TenMon { get; set; }
        public string MoTa { get; set; }
        public double DonGia { get; set; }
        public string TrangThai { get; set; }
        public string HinhAnh { get; set; }
        public int IDLoaiMon { get; set; }
    
        public virtual CHITIETMON CHITIETMON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHD> CHITIETHD { get; set; }
        public virtual LOAIMON LOAIMON { get; set; }
    }
}
