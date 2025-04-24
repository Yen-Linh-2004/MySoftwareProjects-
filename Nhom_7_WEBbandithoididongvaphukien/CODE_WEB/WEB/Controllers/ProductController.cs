using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        QL_DIENTHOAIEntities4 db = new QL_DIENTHOAIEntities4();
        // GET: Product
        public ActionResult SanPham()
        {
            return View(db.SANPHAMs.Distinct().ToList());
        }

        public ActionResult SanPham_full()
        {
            return View(db.SANPHAMs.OrderByDescending(sp => sp.TenSanPham).ToList());
        }

        public ActionResult SanPhamThemDM(int MaDM)
        {
            return View(db.SANPHAMs.Where(s => s.MaDanhMuc == MaDM).ToList());
        }

        public ActionResult PhoBien()
        {
            return View(db.SANPHAMs.Take(30).OrderBy(sp => sp.MoTa).ToList());
        }

        public ActionResult MoiNhat()
        {
            return View(db.SANPHAMs.Take(30).OrderByDescending(sp => sp.SoLuongTon).ToList());
        }

        public ActionResult BanChay()
        {
            return View(db.SANPHAMs.Take(30).OrderBy(sp => sp.SoLuongTon).ToList());
        }

        public ActionResult SanPham_GiaGiam()
        {
            return View(db.SANPHAMs.OrderByDescending(sp => sp.GiaBan).ToList());
        }

        public ActionResult SanPham_GiaTang()
        {
            return View(db.SANPHAMs.OrderBy(sp => sp.GiaBan).ToList());
        }

        public ActionResult XemChiTiet(int id)
        {
            var sanPham = (from sp in db.SANPHAMs
                           join dm in db.DANHMUCs on sp.MaDanhMuc equals dm.MaDanhMuc
                           join ncc in db.NHACUNGCAPs on sp.MaDanhMuc equals ncc.MaNCC
                           where sp.MaSanPham == id
                           select new Detail_SanPham
                           {
                               MaSanPham = sp.MaSanPham,
                               TenSanPham = sp.TenSanPham,
                               MoTa = sp.MoTa,
                               GiaBan = (float)sp.GiaBan,
                               HinhAnh = sp.HinhAnh,
                               DanhMuc = dm.TenDanhMuc,
                               NhaCungCap = ncc.TenNCC
                           }).FirstOrDefault();

            if (sanPham == null) return HttpNotFound();

            return View(sanPham);
        }

    }
}