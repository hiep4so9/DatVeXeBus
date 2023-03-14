using QLXeBuyt.Models;
using QLXeBuyt.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class HoaDonController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Hoadon req)
        {
            db.Hoadons.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int maHD)
        {
            var _hoadon = db.Hoadons.Where(M => M.MaHD == maHD).FirstOrDefault();
            db.Hoadons.DeleteOnSubmit(_hoadon);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int maHD)
        {
            var _hoadon = (from a in db.Hoadons.Where(x => x.MaHD == maHD)
                              select new HoaDonDTO
                              {
                                  MaHD = a.MaHD,
                                  Ngaymua = a.Ngaymua,
                                  Makhachhang = a.Makhachhang,
                                  Trangthai = a.Trangthai,
                                  Tentrangthai = a.Trangthai == 1 ? "Đang sử dụng" : a.Trangthai == 2 ? "Đang chờ thanh toán" : "Đã hết lượt",
                                  Tenkhachhang = db.Khachhangs.Where(x => x.Makhachhang == a.Makhachhang).FirstOrDefault().Ten ?? "Không rõ",
                              }).FirstOrDefault();
            return Json(new { success = true, data = _hoadon }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listHoadon = (from a in db.Hoadons
                              select new HoaDonDTO { 
                                  MaHD = a.MaHD,
                                  Ngaymua = a.Ngaymua,
                                  Makhachhang = a.Makhachhang,
                                  Trangthai = a.Trangthai,
                                  Tentrangthai = a.Trangthai == 1 ? "Đang sử dụng" : a.Trangthai == 2 ? "Đang chờ thanh toán" : "Đã hết lượt",
                                  Tenkhachhang = db.Khachhangs.Where(x => x.Makhachhang == a.Makhachhang).FirstOrDefault().Ten ?? "Không rõ"
                              }).ToList();
            ViewBag.ListHoaDon = listHoadon;
            return View();
        }

        public ActionResult List()
        {
            var listHoadon = (from a in db.Hoadons
                              select new HoaDonDTO
                              {
                                  MaHD = a.MaHD,
                                  Ngaymua = a.Ngaymua,
                                  Makhachhang = a.Makhachhang,
                                  Trangthai = a.Trangthai,
                                  Tentrangthai = a.Trangthai == 1 ? "Chưa sử dụng" : "Đã qua sử dụng",
                                  Tenkhachhang = db.Khachhangs.Where(x => x.Makhachhang == a.Makhachhang).FirstOrDefault().Ten ?? "Không rõ"
                              }).ToList();
            return Json(new { success = true, data = listHoadon }, JsonRequestBehavior.AllowGet);
        }
    }
}