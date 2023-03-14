using QLXeBuyt.Models;
using QLXeBuyt.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class XeController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Xe req)
        {
            if (req.MaXe > 0)
            {
                var _xe = db.Xes.Where(x => x.MaXe == req.MaXe).FirstOrDefault();
                _xe.Thoigianhoatdong = req.Thoigianhoatdong;
                _xe.Thoigianchay = req.Thoigianchay;
                _xe.Bienso = req.Bienso;
                _xe.Trangthai = req.Trangthai;
                _xe.Matuyen = req.Matuyen;
                _xe.Sochongoi = req.Sochongoi;
                db.SubmitChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            db.Xes.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int maxe)
        {
            var _xe = db.Xes.Where(M => M.MaXe == maxe).FirstOrDefault();
            db.Xes.DeleteOnSubmit(_xe);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int maxe)
        {
            var _xe = (from a in db.Xes
                          select new XeDTO
                          {
                              MaXe = a.MaXe,
                              Thoigianhoatdong = a.Thoigianhoatdong,
                              Thoigianchay = a.Thoigianchay,
                              Bienso = a.Bienso,
                              Trangthai = a.Trangthai,
                              Matuyen = a.Matuyen,
                              Tentuyen = db.Tuyenxes.Where(x => x.Matuyen == a.Matuyen).FirstOrDefault().Tentuyen ?? "Không xác định",
                              Sochongoi = a.Sochongoi
                          }).Where(xe => xe.MaXe == maxe).FirstOrDefault();
            return Json(new { success = true, data = _xe }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listXe = (from a in db.Xes
                          select new XeDTO { 
                                MaXe = a.MaXe,
                                Thoigianhoatdong = a.Thoigianhoatdong,
                                Thoigianchay = a.Thoigianchay,
                                Bienso = a.Bienso,
                                Trangthai = a.Trangthai,
                                Matuyen = a.Matuyen,
                                Tentuyen = db.Tuyenxes.Where(x => x.Matuyen == a.Matuyen).FirstOrDefault().Tentuyen ?? "Không xác định",
                                Sochongoi = a.Sochongoi
                          }).ToList();
            var listTuyenXe = db.Tuyenxes.ToList();
            ViewBag.ListXe = listXe;
            ViewBag.ListTuyenXe = listTuyenXe;
            return View();
        }
    }
}