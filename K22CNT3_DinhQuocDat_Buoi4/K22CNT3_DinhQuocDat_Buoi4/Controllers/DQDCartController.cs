using K22CNT3_DinhQuocDat_Buoi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K22CNT3_DinhQuocDat_Buoi4.Models;
using K22CNT3_DinhQuocDat_Buoi4.Bussiness;

namespace K22CNT3_DinhQuocDat_Buoi4.Controllers
{

    public class DQDCartController : Controller
    {
        private const string DQDCartSessionKey = "DQDCartSessionKey";
        DQDDbEntities dbEntities = new DQDDbEntities();

        private DQD_ShoppingCart GetCart()
        {
            var cart = Session[DQDCartSessionKey] as DQD_ShoppingCart;
            if (cart == null)
            {
                cart = new DQD_ShoppingCart();
                Session[DQDCartSessionKey] = cart;
            }

            return cart;
        }
        // Add to cart: them mot san pham vao gio hang
        public ActionResult AddToCart(int id, string TenDienThoai, String HinhAnh, int SoLuongMua, float DonGiaMua)
        {
            var cart = GetCart();
            var item = new DQDCartItem
            {
                ID = id,
                TenDienThoai = TenDienThoai,
                HinhAnh = HinhAnh,
                SoLuongMua = SoLuongMua,
                DonGiaMua = DonGiaMua,
                ThanhTien = SoLuongMua * DonGiaMua
            };

            cart.AddToCart(item);
            return RedirectToAction("Index");

        }


        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart.Items);
        }

        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            ViewBag.TongTriGia = cart.GetTongThanhTien();
            DateTime dt = DateTime.Now;
            var MaHoaDon = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            ViewBag.MaHoaDon = MaHoaDon;
            return View(cart.Items);
        }

        public ActionResult ThanhToan(FormCollection form)
        {
            var cart = GetCart();

            var HoTenKhachHang = form["HoTenKhachHang"];
            var Email = form["Email"];
            var DienThoai = form["DienThoai"];
            var DiaChi = form["DiaChi"];

            DateTime dt = DateTime.Now;
            var MaHoaDon = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            var NgayNhan = form["NgayNhan"];
            var TriGia = cart.GetTongThanhTien();

            var hoaDon = new HOA_DON
            {
                MaHoaDon = MaHoaDon,
                KhachHangID = 1,
                NgayHoaDon = dt,
                NgayNhan = DateTime.Parse(NgayNhan),
                TongTriGia = TriGia,
                HoTenKhachHang = HoTenKhachHang,
                Email = Email,
                DienThoai = DienThoai,
                DiaChi = DiaChi,
                TrangThai = 0
            };

            dbEntities.HOA_DON.Add(hoaDon);
            dbEntities.SaveChanges();

            int hoaDonId = dbEntities.HOA_DON.Max(x => x.ID);

            foreach (var item in cart.Items)
            {
                var ct = new CT_HOA_DON
                {
                    HoaDonID = hoaDonId,
                    DienThoaiID = item.ID,
                    SoLuongMua = item.SoLuongMua,
                    DonGiaMua = item.DonGiaMua,
                    ThanhTien = item.ThanhTien
                };

                dbEntities.CT_HOA_DON.Add(ct);
                dbEntities.SaveChanges();
            }

            return RedirectToAction("CamOn");
        }

        public ActionResult CamOn()
        {
            return View();
        }

        public ActionResult UpdateFromCart(FormCollection form)
        {
            var cart = GetCart();
            var ids = form["ID"].Split(',');
            var qtys = form["SoLuongMua"].Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                int id = int.Parse(ids[i]);
                int qty = int.Parse(qtys[i]);
                cart.UpdateFromCart(id, qty);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateItemCart(int id, int qty)
        {
            var cart = GetCart();
            cart.UpdateFromCart(id, qty);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItemCart(int id)
        {
            var cart = GetCart();
            cart.RemoveCartItem(id);
            return RedirectToAction("Index");
        }
    }
}
