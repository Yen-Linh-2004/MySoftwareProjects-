using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;


namespace WEB.Controllers
{
    public class AdminController : Controller
    {
        QL_DIENTHOAIEntities4 db = new QL_DIENTHOAIEntities4();
        // ========================= Trang chủ Admin =========================
        [HttpGet]
        public ActionResult Index()
        {
            // Fetch total user count
            int totalUsers = db.USERS.Count();
            ViewBag.TotalUsers = totalUsers;

            // Fetch user list with details
            var users = db.USERS
                .Include(u => u.KHACHHANG)
                .Include(u => u.NHANVIEN)
                .ToList();

            return View(users);
        }
        // ========================= Khách hàng =========================
        [HttpGet]
        public ActionResult ListCustomers()
        {
            var customers = db.KHACHHANGs.ToList();
            ViewBag.Count = customers.Count();
            return View(db.KHACHHANGs.ToList());
        }
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(KHACHHANG customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string validationMessage = ValidateCustomer(customer, false);

                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        ViewBag.FailMessage = validationMessage;
                        return View(customer);
                    }

                    customer.LoaiKH = "Khách hàng mới";

                    db.KHACHHANGs.Add(customer);
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Khách hàng đã được thêm thành công!";

                    return View(new KHACHHANG());
                }
                catch
                {
                    ViewBag.FailMessage = "Lỗi khi thêm khách hàng!";

                    return View(customer);
                }
            }

            return View(customer);
        }

        public ActionResult DeleteCustomer(int id)
        {
            KHACHHANG customer = db.KHACHHANGs.SingleOrDefault(item => item.MaKhachHang == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("DeleteCustomer")]
        public ActionResult DeleteCustomer(int id, bool? confirmDeleteGioHang)
        {
            var customer = db.KHACHHANGs.SingleOrDefault(kh => kh.MaKhachHang == id);

            if (customer == null)
            {
                ViewBag.FailMessage = "Không tìm thấy khách hàng!";
                return RedirectToAction("ListCustomer");
            }

            string validationMessage = ValidateCustomerWhenDelete(id);

            if (!string.IsNullOrEmpty(validationMessage) && confirmDeleteGioHang == null)
            {
                ViewBag.ValidationMessage = validationMessage;
                return View(customer); // Hiển thị xác nhận
            }

            if (confirmDeleteGioHang == true)
            {
                // Nếu người dùng đồng ý xóa, xóa cả giỏ hàng
                var gioHangs = db.GIOHANGs.Where(gh => gh.MaGioHang == id).ToList();
                db.GIOHANGs.RemoveRange(gioHangs);
            }
            else if (confirmDeleteGioHang == false)
            {
                // Nếu người dùng không đồng ý, hủy việc xóa khách hàng
                ViewBag.FailMessage = "Hủy xóa khách hàng!";
                return RedirectToAction("ListCustomer");
            }

            // Xóa khách hàng
            db.KHACHHANGs.Remove(customer);
            db.SaveChanges();

            ViewBag.SuccessMessage = "Xóa khách hàng thành công!";
            return RedirectToAction("ListCustomer");
        }

        public ActionResult UpdateCustomer(int id = 0)
        {
            KHACHHANG customer = db.KHACHHANGs.SingleOrDefault(item => item.MaKhachHang == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(KHACHHANG customer)
        {
            if (ModelState.IsValid)
            {
                string validationMessage = ValidateCustomer(customer, true);

                if (!string.IsNullOrEmpty(validationMessage))
                {
                    ViewBag.FailMessage = validationMessage;
                    return View(customer);
                }

                var existingCustomer = db.KHACHHANGs.SingleOrDefault(item => item.MaKhachHang == customer.MaKhachHang);

                if (existingCustomer == null)
                {
                    ViewBag.FailMessage = "Khách hàng không tồn tại!";
                    return View(customer);
                }

                try
                {
                    //db.KHACHHANGs.Attach(customer);
                    //db.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                    db.Entry(existingCustomer).CurrentValues.SetValues(customer);
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Cập nhật thông tin thành công!";

                    return View(existingCustomer);
                    //return RedirectToAction("ShowTopTenCustomers", "Customer");
                }
                catch
                {
                    ViewBag.FailMessage = "Cập nhật thông tin thất bại!";
                    return View(customer);
                }
            }

            ViewBag.FailMessage = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại!";
            return View(customer);
        }

        private string ValidateCustomer(KHACHHANG customer, bool isUpdate = false)
        {
            KHACHHANG existingCustomerName = db.KHACHHANGs.SingleOrDefault(item => item.HoTen.Equals(customer.HoTen, StringComparison.Ordinal)
                                                                                   && (!isUpdate || item.MaKhachHang != customer.MaKhachHang));

            if (existingCustomerName != null)
            {
                return "Họ tên khách hàng đã tồn tại!";
            }

            KHACHHANG existingCustomerEmail = db.KHACHHANGs.SingleOrDefault(item => item.Email.Equals(customer.Email, StringComparison.Ordinal)
                                                                                    && (!isUpdate || item.MaKhachHang != customer.MaKhachHang));

            if (existingCustomerEmail != null)
            {
                return "Email khách hàng đã tồn tại!";
            }

            KHACHHANG existingCustomerPhone = db.KHACHHANGs.SingleOrDefault(item => item.SoDienThoai.Equals(customer.SoDienThoai, StringComparison.Ordinal)
                                                                                    && (!isUpdate || item.MaKhachHang != customer.MaKhachHang));

            if (existingCustomerPhone != null)
            {
                return "Số điện thoại khách hàng đã tồn tại!";
            }

            return string.Empty;
        }

        private string ValidateCustomerWhenDelete(int maKhachHang)
        {
            if (db.GIOHANGs.Any(gh => gh.MaGioHang == maKhachHang))
            {
                return "Khách hàng đã tồn tại trong bảng GIOHANG. Bạn có muốn xóa cả giỏ hàng không?";
            }

            return string.Empty; // Không có vấn đề gì, có thể xóa
        }
        // ========================= Nhân Viên =========================
        [HttpGet]
        public ActionResult ListEmployee()
        {
            var Employees = db.NHANVIENs.ToList();
            ViewBag.Count = Employees.Count();
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(db.NHANVIENs.ToList());
        }
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(NHANVIEN employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string validationMessage = ValidateEmployee(employee, false);

                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        ViewBag.FailMessage = validationMessage;
                        return View(employee);
                    }

                    db.NHANVIENs.Add(employee);
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Nhân viên đã được thêm thành công!";

                    return View(new NHANVIEN());
                }
                catch
                {
                    ViewBag.FailMessage = "Lỗi khi thêm nhân viên!";

                    return View(employee);
                }
            }

            return View(employee);
        }

        public ActionResult DeleteEmployee(int id)
        {
            NHANVIEN employee = db.NHANVIENs.SingleOrDefault(item => item.MaNhanVien == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult ConfirmDeleteEmployee(int id)
        {
            NHANVIEN employeeToDelete = db.NHANVIENs.SingleOrDefault(item => item.MaNhanVien == id);

            if (employeeToDelete == null)
            {
                ViewBag.FailMessage = "Nhân viên không tồn tại.";
                return RedirectToAction("Index");
            }

            try
            {
                db.Entry(employeeToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                TempData["SuccessMessage"] = $"Nhân viên '{employeeToDelete.HoTen}' đã được xóa thành công!";
                return RedirectToAction("ListEmployee"); // Quay về danh sách sau khi xóa
            }
            catch (Exception ex)
            {
                ViewBag.FailMessage = "Có lỗi xảy ra khi xóa nhân viên: " + ex.Message;
                return View(employeeToDelete);
            }
        }

        public ActionResult UpdateEmployee(int id = 0)
        {
            NHANVIEN employee = db.NHANVIENs.SingleOrDefault(item => item.MaNhanVien == id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(NHANVIEN employee)
        {
            if (ModelState.IsValid)
            {

                string validationMessage = ValidateEmployee(employee, true);

                if (!string.IsNullOrEmpty(validationMessage))
                {
                    ViewBag.FailMessage = validationMessage;
                    return View(employee);
                }

                var existingEmployee = db.NHANVIENs.SingleOrDefault(item => item.MaNhanVien == employee.MaNhanVien);

                if (existingEmployee == null)
                {
                    ViewBag.FailMessage = "Nhân viên không tồn tại!";
                    return View(employee);
                }

                try
                {
                    db.Entry(existingEmployee).CurrentValues.SetValues(employee);
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Cập nhật thông tin thành công!";

                    return RedirectToAction("ListEmployee");
                }
                catch
                {
                    ViewBag.FailMessage = "Cập nhật thông tin thất bại!";
                    return View(employee);
                }
            }

            ViewBag.FailMessage = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại!";
            return View(employee);
        }

        private string ValidateEmployee(NHANVIEN employee, bool isUpdate = false)
        {
            var existingEmployeeName = db.NHANVIENs.SingleOrDefault(item => item.HoTen.Equals(employee.HoTen, StringComparison.Ordinal)
                                                                    && (!isUpdate || item.MaNhanVien != employee.MaNhanVien));

            if (existingEmployeeName != null)
            {
                return "Họ tên nhân viên đã tồn tại";
            }

            var existingEmployeeEmail = db.NHANVIENs.SingleOrDefault(item => item.Email.Equals(employee.Email, StringComparison.Ordinal)
                                                                    && (!isUpdate || item.MaNhanVien != employee.MaNhanVien));

            if (existingEmployeeEmail != null)
            {
                return "Email nhân viên đã tồn tại";
            }

            var existingEmployeePhone = db.NHANVIENs.SingleOrDefault(item => item.SoDienThoai.Equals(employee.SoDienThoai, StringComparison.Ordinal)
                                                                    && (!isUpdate || item.MaNhanVien != employee.MaNhanVien));

            if (existingEmployeePhone != null)
            {
                return "Số điện thoại nhân viên đã tồn tại";
            }

            return string.Empty;
        }

        private string ValidateEmployeeWhenDelete(int maNhanVien)
        {
            if (db.HOADONs.Any(d => d.MaNhanVien == maNhanVien))
            {
                return "Không thể xóa nhân viên vì đã tồn tại trong bảng DONHANG";
            }

            return string.Empty;
        }
        // ========================= Sản phẩm =========================
        public ActionResult ListProducts(int? categoryId)
        {
            var products = db.SANPHAMs.Include(s => s.DANHMUC);
            ViewBag.Count = products.Count();
            // Lọc theo danh mục nếu có
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.MaDanhMuc == categoryId);
            }

            // Lấy danh sách danh mục cho dropdown
            ViewBag.Categories = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", categoryId);

            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var product = db.SANPHAMs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            // Lấy danh sách danh mục để hiển thị trong dropdown
            ViewBag.DanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", product.MaDanhMuc);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(SANPHAM product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListProducts");
            }
            ViewBag.DanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", product.MaDanhMuc);
            return View(product);
        }
        public ActionResult DeleteProduct()
        {
            SANPHAM sp = db.SANPHAMs.Include("DANHMUC").SingleOrDefault(item => item.MaSanPham == 1);

            if (sp == null)
            {
                return HttpNotFound();
            }

            return View(sp);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteProductConfirm(int id)
        {
            string validationMessage = ValidateProductWhenDelete(id);

            if (!string.IsNullOrEmpty(validationMessage))
            {
                ViewBag.FailMessage = validationMessage;
                return View();
            }

            SANPHAM sp = db.SANPHAMs.SingleOrDefault(item => item.MaSanPham == id);

            if (sp == null)
            {
                ViewBag.FailMessage = "Sản phẩm không tìm thấy.";
                return View();
            }

            db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            ViewBag.SuccessMessage = "Sản phẩm '" + sp.TenSanPham + "' đã xoá thành công!";
            return View(sp);
        }

        private string ValidateProductWhenDelete(int maSanPham)
        {
            if (db.GIOHANGs.Any(gh => gh.MaSanPham == maSanPham))
            {
                return "Không thể xóa sản phẩm vì đã tồn tại trong bảng GIOHANG!";
            }

            if (db.CHITIETHDs.Any(ctdh => ctdh.MaSanPham == maSanPham))
            {
                return "Không thể xóa sản phẩm vì đã tồn tại trong bảng CHITIETDH!";
            }

            if (db.DANHGIAs.Any(dg => dg.MaSanPham == maSanPham))
            {
                return "Không thể xóa sản phẩm vì đã tồn tại trong bảng DANHGIA!";
            }

            if (db.CHITIETPNs.Any(ctpn => ctpn.MaSanPham == maSanPham))
            {
                return "Không thể xóa sản phẩm vì đã tồn tại trong bảng CHITIETPN!";
            }

            return string.Empty;
        }
        // ========================= Trạng thái đơn hàng =========================
        [HttpGet]
        public ActionResult TrangThaiDonHang()
        {
            // Fetch all orders and group them by order status
            var trangThaiDonHangs = db.HOADONs
                .Select(hd => new
                {
                    MaHoaDon = hd.MaHoaDon,
                    MaKhachHang = hd.MaKhachHang,
                    MaNhanVien = hd.MaNhanVien,
                    TongTien = hd.TongTien,
                    TrangThaiDH = hd.TrangThaiDH,
                    PhuongThucTT = hd.PhuongThucTT,
                    TrangThaiTT = hd.TrangThaiTT,
                    NgayDatHang = hd.NgayDatHang,
                    NgayGH = hd.NgayGH,
                    GhiChu = hd.GhiChu
                })
                .ToList();

            // Pass data to the view
            return View(trangThaiDonHangs);
        }

    }
}