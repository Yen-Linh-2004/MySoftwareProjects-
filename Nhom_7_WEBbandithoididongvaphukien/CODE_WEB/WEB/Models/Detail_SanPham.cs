using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Detail_SanPham
    {          
           public int MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string MoTa { get; set; }
            public float GiaBan { get; set; }
            public string HinhAnh { get; set; }
            public string DanhMuc { get; set; }
            public string NhaCungCap { get; set; }
    }
}