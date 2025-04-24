using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using System.Data.Entity;

namespace WEB.Controllers
{
    public class CartController : Controller
    {
        private QL_DIENTHOAIEntities4 db = new QL_DIENTHOAIEntities4();

        // GET: Cart
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
                return RedirectToAction("DangNhap", "Home");

            string userName = Session["UserName"].ToString();
            string password = Session["PasswordHash"].ToString();
            var user = db.USERS.FirstOrDefault(u => u.Username == userName);
            var pass = db.USERS.FirstOrDefault(u => u.PasswordHash == password);

            if (user == null && pass==null)
                return RedirectToAction("DangNhap", "Home");

            var cartItems = db.GIOHANGs
                .Where(g => g.MaKhachHang == user.MaKhachHang) .ToList();

            return View(cartItems);
        }


        // POST: Cart/AddToCart
        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity = 1)
        {
            if (Session["UserID"] == null)
                return Json(new { success = false, message = "Vui lòng đăng nhập để thêm vào giỏ hàng" });

            int userId = (int)Session["UserID"];
            var user = db.USERS.Find(userId);

            if (user.MaKhachHang == null)
                return Json(new { success = false, message = "Tài khoản không hợp lệ" });

            var product = db.SANPHAMs.Find(productId);
            if (product == null)
                return Json(new { success = false, message = "Sản phẩm không tồn tại" });

            if (product.SoLuongTon < quantity)
                return Json(new { success = false, message = "Số lượng sản phẩm không đủ" });

            var existingItem = db.GIOHANGs.FirstOrDefault(g =>
                g.MaKhachHang == user.MaKhachHang && g.MaSanPham == productId);

            if (existingItem != null)
            {
                existingItem.SoLuong += quantity;
                existingItem.TongTien = existingItem.SoLuong * product.GiaBan;
            }
            else
            {
                var cartItem = new GIOHANG
                {
                    MaKhachHang = (int)user.MaKhachHang,
                    MaSanPham = productId,
                    SoLuong = quantity,
                //    TongTien = quantity * product.GiaBan,
                    NgayThem = DateTime.Now
                };
                db.GIOHANGs.Add(cartItem);
            }

            db.SaveChanges();
            return Json(new { success = true, message = "Đã thêm vào giỏ hàng" });
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        public ActionResult UpdateQuantity(int cartItemId, int quantity)
        {
            var cartItem = db.GIOHANGs.Find(cartItemId);
            if (cartItem == null)
                return Json(new { success = false, message = "Không tìm thấy sản phẩm trong giỏ hàng" });

            var product = db.SANPHAMs.Find(cartItem.MaSanPham);
            if (product.SoLuongTon < quantity)
                return Json(new { success = false, message = "Số lượng sản phẩm không đủ" });

            cartItem.SoLuong = quantity;
         //   cartItem.TongTien = quantity * product.GiaBan;
            db.SaveChanges();

            return Json(new { success = true, message = "Đã cập nhật số lượng" });
        }

        // POST: Cart/RemoveItem
        [HttpPost]
        public ActionResult RemoveItem(int cartItemId)
        {
            var cartItem = db.GIOHANGs.Find(cartItemId);
            if (cartItem == null)
                return Json(new { success = false, message = "Không tìm thấy sản phẩm trong giỏ hàng" });

            db.GIOHANGs.Remove(cartItem);
            db.SaveChanges();

            return Json(new { success = true, message = "Đã xóa sản phẩm khỏi giỏ hàng" });
        }

        // GET: Cart/Checkout
        public ActionResult Checkout()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("DangNhap", "Home");

            int userId = (int)Session["UserID"];
            var user = db.USERS.Find(userId);

            if (user.MaKhachHang == null)
                return RedirectToAction("DangNhap", "Home");

            var cartItems = db.GIOHANGs
                .Where(g => g.MaKhachHang == user.MaKhachHang)
                .Include("KHACHHANG")
                .ToList();

            if (!cartItems.Any())
                return RedirectToAction("Index");

            var customer = db.KHACHHANGs.Find(user.MaKhachHang);
            ViewBag.Customer = customer;

            return View(cartItems);
        }

        // POST: Cart/ProcessCheckout
        [HttpPost]
        public ActionResult ProcessCheckout(string paymentMethod)
        {
            if (Session["UserID"] == null)
                return Json(new { success = false, message = "Vui lòng đăng nhập để thanh toán" });

            int userId = (int)Session["UserID"];
            var user = db.USERS.Find(userId);

            if (user.MaKhachHang == null)
                return Json(new { success = false, message = "Tài khoản không hợp lệ" });

            var cartItems = db.GIOHANGs
                .Where(g => g.MaKhachHang == user.MaKhachHang)
                .Include("SANPHAM")
                .ToList();

            if (!cartItems.Any())
                return Json(new { success = false, message = "Giỏ hàng trống" });

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Tạo đơn hàng mới
                    var order = new HOADON
                    {
                        MaKhachHang = user.MaKhachHang,
                        NgayDatHang = DateTime.Now,
                        TongTien = (int)cartItems.Sum(i => i.TongTien ?? 0),
                        TrangThaiDH = "Chờ xử lý",
                        PhuongThucTT = paymentMethod,
                        TrangThaiTT = "Chưa thanh toán",
                        NgayDHDK = DateTime.Now
                    };
                    db.HOADONs.Add(order);
                    db.SaveChanges();

                    // Tạo chi tiết đơn hàng
                    foreach (var item in cartItems)
                    {
                        var orderDetail = new CHITIETHD
                        {
                            MaHoaDon = order.MaHoaDon,
                            MaSanPham = item.MaSanPham,
                            SoLuong = item.SoLuong,
                            DonGia = item.SANPHAM.GiaBan
                           
                        };
                        db.CHITIETHDs.Add(orderDetail);

                        // Cập nhật số lượng sản phẩm
                        var product = item.SANPHAM;
                        product.SoLuongTon -= item.SoLuong;
                    }

                    // Xóa giỏ hàng
                    db.GIOHANGs.RemoveRange(cartItems);
                    db.SaveChanges();

                    transaction.Commit();
                    return Json(new { success = true, message = "Đặt hàng thành công", orderId = order.MaDonHang });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Lỗi khi xử lý đơn hàng: " + ex.Message });
                }
            }
        }
    }
}