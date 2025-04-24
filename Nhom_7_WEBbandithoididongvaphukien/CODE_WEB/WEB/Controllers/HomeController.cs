using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        QL_DIENTHOAIEntities4 db = new QL_DIENTHOAIEntities4();

        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(string email, string fullName, string phone, string diaChi, string password)
        {
            try
            {
                // Kiểm tra vai trò mặc định (ở đây mặc định là "Khách hàng")
                string role = "Khách hàng"; // Bạn có thể điều chỉnh theo nhu cầu.

                // Thêm người dùng vào bảng KHACHHANG
                var khachHang = new KHACHHANG // Tạo bản ghi khách hàng mới nếu cần
                {
                    HoTen = fullName,
                    Email = email,
                    SoDienThoai = phone,
                    DiaChi = diaChi
                };

                db.KHACHHANGs.Add(khachHang); // Thêm vào bảng KHACHHANG
                db.SaveChanges(); // Lưu lại để lấy MaKhachHang

                // Lấy MaKhachHang vừa tạo
                int maKhachHang = khachHang.MaKhachHang;

                // Thêm vào bảng USERS
                USER newUser = new USER
                {
                    Username = email, // Đặt Username là email
                    PasswordHash = password, // Lưu mật khẩu thô
                    Roles = role,
                    MaKhachHang = maKhachHang
                };

                db.USERS.Add(newUser); // Thêm vào bảng USERS
                db.SaveChanges(); // Lưu lại
                ViewBag.Message = "Đăng ký thành công!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đăng ký thất bại: " + ex.Message;
            }
            return View();
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(USER model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = (model.PasswordHash);

                var user = db.USERS.FirstOrDefault(u =>
                    u.Username == model.Username &&
                    u.PasswordHash == hashedPassword);

                if (user != null)
                {
                    // Lưu thông tin đăng nhập vào Session
                    Session["UserID"] = user.UserID;
                    Session["Username"] = user.Username;
                    Session["Role"] = user.Roles;


                    // Chuyển hướng theo role
                    switch (user.Roles)
                    {
                        case "Khách hàng":
                            return RedirectToAction("BanChay", "Product");
                        case "Nhân viên":
                            return RedirectToAction("IndexNhanVien", "NhanVien");
                        case "Admin":
                            return RedirectToAction("Index", "Admin");
                        default:
                            return RedirectToAction("DangNhap", "Home");
                    }
                }

                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
            }

            return View(model);
        }
    }
}