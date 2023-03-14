using QLXeBuyt.Models;
using QLXeBuyt.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class NhanVienController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(NhanVienDTO req)
        {
            if (req.Manhanvien > 0)
            {
                var _nhanvien = db.Nhanviens.Where(x => x.Manhanvien == req.Manhanvien).FirstOrDefault();
                _nhanvien.Ten = req.Ten;
                _nhanvien.Ngaysinh = req.Ngaysinh;
                _nhanvien.Diachi = req.Diachi;
                _nhanvien.Gioitinh = req.Gioitinh;
                _nhanvien.Ngayvaolam = req.Ngayvaolam;
                _nhanvien.Chucvu = req.Chucvu;
                _nhanvien.Luong = req.Luong;
                _nhanvien.CCCD = req.CCCD;
                db.SubmitChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            var _taikhoan = new Taikhoan();
            _taikhoan.Tentaikhoan = req.Taikhoan.Tentaikhoan;
            _taikhoan.Matkhau = req.Taikhoan.Matkhau;
            _taikhoan.Email = req.Taikhoan.Email;
            _taikhoan.Sodienthoai = req.Taikhoan.Sodienthoai;
            _taikhoan.Code = req.Taikhoan.Code;
            _taikhoan.Tinhtrang = req.Taikhoan.Tinhtrang;
            _taikhoan.Sodu = req.Taikhoan.Sodu;
            _taikhoan.Maloai = "03";

            db.Taikhoans.InsertOnSubmit(_taikhoan);
            db.SubmitChanges();

            var _nhanvienInsert = new Nhanvien();
            _nhanvienInsert.Ten = req.Ten;
            _nhanvienInsert.Ngaysinh = req.Ngaysinh;
            _nhanvienInsert.Diachi = req.Diachi;
            _nhanvienInsert.Gioitinh = req.Gioitinh;
            _nhanvienInsert.Ngayvaolam = req.Ngayvaolam;
            _nhanvienInsert.Chucvu = req.Chucvu;
            _nhanvienInsert.Luong = req.Luong;
            _nhanvienInsert.CCCD = req.CCCD;
            _nhanvienInsert.Id_Taikhoan = _taikhoan.Id_Taikhoan;

            db.Nhanviens.InsertOnSubmit(_nhanvienInsert);
            db.SubmitChanges();
            return Json(new { success = true, data = req }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int manhanvien)
        {
            var _nhanvien = db.Nhanviens.Where(M => M.Manhanvien == manhanvien).FirstOrDefault();
            db.Nhanviens.DeleteOnSubmit(_nhanvien);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int manhanvien)
        {
            var _nhanhvien = (from a in db.Nhanviens.Where(x => x.Manhanvien == manhanvien)
                              select new NhanVienDTO
                              {
                                  Manhanvien = a.Manhanvien,
                                  Ten = a.Ten,
                                  Ngaysinh = a.Ngaysinh,
                                  Diachi = a.Diachi,
                                  Gioitinh = a.Gioitinh,
                                  Ngayvaolam = a.Ngayvaolam,
                                  Chucvu = a.Chucvu,
                                  Luong = a.Luong,
                                  CCCD = a.CCCD,
                                  Id_Taikhoan = a.Id_Taikhoan,
                                  Tentaikhoan = db.Taikhoans.Where(x => x.Id_Taikhoan == a.Id_Taikhoan).FirstOrDefault().Tentaikhoan ?? "Không xác định",
                                  Tengioitinh = a.Gioitinh == true ? "Nam" : "Nữ"
                              }).FirstOrDefault();
            return Json(new { success = true, data = _nhanhvien }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listNhanVien = (from a in db.Nhanviens.Where(k => db.Taikhoans.Where(t => t.Id_Taikhoan == k.Id_Taikhoan).FirstOrDefault().Maloai == "03")
                              select new NhanVienDTO
                              {
                                  Manhanvien = a.Manhanvien,
                                  Ten = a.Ten,
                                  Ngaysinh = a.Ngaysinh,
                                  Diachi = a.Diachi,
                                  Gioitinh = a.Gioitinh,
                                  Ngayvaolam = a.Ngayvaolam,
                                  Chucvu = a.Chucvu,
                                  Luong = a.Luong,
                                  CCCD = a.CCCD,
                                  Id_Taikhoan = a.Id_Taikhoan,
                                  Tentaikhoan = db.Taikhoans.Where(x => x.Id_Taikhoan == a.Id_Taikhoan).FirstOrDefault().Tentaikhoan ?? "Không xác định",
                                  Tengioitinh = a.Gioitinh == true ? "Nam" : "Nữ"
                              }).ToList();
            ViewBag.ListNhanVien = listNhanVien;
            return View();
        }

        public ActionResult List()
        {
            var listNhanVien = (from a in db.Nhanviens.Where(k => db.Taikhoans.Where(t => t.Id_Taikhoan == k.Id_Taikhoan).FirstOrDefault().Maloai == "03")
                                select new NhanVienDTO
                                {
                                    Manhanvien = a.Manhanvien,
                                    Ten = a.Ten,
                                    Ngaysinh = a.Ngaysinh,
                                    Diachi = a.Diachi,
                                    Gioitinh = a.Gioitinh,
                                    Ngayvaolam = a.Ngayvaolam,
                                    Chucvu = a.Chucvu,
                                    Luong = a.Luong,
                                    CCCD = a.CCCD,
                                    Id_Taikhoan = a.Id_Taikhoan,
                                    Tentaikhoan = db.Taikhoans.Where(x => x.Id_Taikhoan == a.Id_Taikhoan).FirstOrDefault().Tentaikhoan ?? "Không xác định",
                                    Tengioitinh = a.Gioitinh == true ? "Nam" : "Nữ"
                                }).ToList();
            return Json(new { success = true, data = listNhanVien }, JsonRequestBehavior.AllowGet);
        }
    }
}