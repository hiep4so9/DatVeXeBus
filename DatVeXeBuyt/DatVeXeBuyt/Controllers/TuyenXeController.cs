using QLXeBuyt.Models;
using QLXeBuyt.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class TuyenXeController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Tuyenxe req)
        {
            if (req.Matuyen > 0)
            {
                var _tuyenxe = db.Tuyenxes.Where(x => x.Matuyen == req.Matuyen).FirstOrDefault();
                _tuyenxe.Tuyenso = req.Tuyenso;
                _tuyenxe.Tentuyen = req.Tentuyen;
                _tuyenxe.Thoigianbatdau = req.Thoigianbatdau;
                _tuyenxe.Thoigianketthuc = req.Thoigianketthuc;
                _tuyenxe.Luotdi = req.Luotdi;
                _tuyenxe.Luotve = req.Luotve;
                _tuyenxe.Loaituyen = req.Loaituyen;
                _tuyenxe.Thoigianchay = req.Thoigianchay;
                _tuyenxe.Giancachtuyen = req.Giancachtuyen;
                _tuyenxe.Sochuyen = req.Sochuyen;
                db.SubmitChanges();
                return Json(new { success = true, data = _tuyenxe }, JsonRequestBehavior.AllowGet);
            }

            db.Tuyenxes.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true, data = req }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int matuyen)
        {
            var _tuyenxe = db.Tuyenxes.Where(M => M.Matuyen == matuyen).FirstOrDefault();
            db.Tuyenxes.DeleteOnSubmit(_tuyenxe);
            db.SubmitChanges();
            return Json(new { success = true, data = _tuyenxe }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int matuyen)
        {
            var _tuyenxe = db.Tuyenxes.Where(M => M.Matuyen == matuyen).FirstOrDefault();
            return Json(new { success = true, data = _tuyenxe }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listTuyenXe = db.Tuyenxes.ToList();
            ViewBag.ListTuyenXe = listTuyenXe;
            return View();
        }
        public ActionResult List()
        {

            var tuyenxe = (from a in db.Tuyenxes
                           select new TuyenxeDTO
                           {
                               MaTuyen = a.Matuyen,
                               TuyenSo = a.Tuyenso.GetValueOrDefault(),
                               TenTuyen = a.Tentuyen,
                               ThoiGianBatDau = a.Thoigianbatdau.GetValueOrDefault(),
                               ThoiGianKetThuc = a.Thoigianketthuc.GetValueOrDefault(),
                               LuotDi = a.Luotdi,
                               LuotVe = a.Luotve,
                               LoaiTuyen = a.Loaituyen,
                               ThoiGianChay = a.Thoigianchay,
                               GianCachTuyen = a.Giancachtuyen,
                               SoChuyen = a.Sochuyen.GetValueOrDefault(),
                               Giatien = db.VeXes.Where(x => x.Tuyenxe.Matuyen == a.Matuyen).FirstOrDefault().Giatien ?? 0
                           }).ToList();
            return Json(new { success = true, data = tuyenxe }, JsonRequestBehavior.AllowGet);



        }
    }
}