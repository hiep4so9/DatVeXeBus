using QLXeBuyt.Models;
using QLXeBuyt.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class VeXeController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(VeXe req)
        {
            if (req.Mave > 0)
            {
                var _vexe = db.VeXes.Where(x => x.Mave == req.Mave).FirstOrDefault();
                _vexe.Ngayphathanh = req.Ngayphathanh;
                _vexe.Ngayhethan = req.Ngayhethan;
                _vexe.Tinhtrang = req.Tinhtrang;
                _vexe.Matuyen = req.Matuyen;
                _vexe.Loaive = req.Loaive;
                _vexe.Vethang = req.Vethang;
                _vexe.Giatien = req.Giatien;
                db.SubmitChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            db.VeXes.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int mave)
        {
            var _vexe = db.VeXes.Where(M => M.Mave == mave).FirstOrDefault();
            db.VeXes.DeleteOnSubmit(_vexe);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int mave)
        {
            var _xe = (from a in db.VeXes
                       select new VeXeDTO
                       {
                           Mave = a.Mave,
                           Ngayphathanh = a.Ngayphathanh,
                           Ngayhethan = a.Ngayhethan,
                           Tinhtrang = a.Tinhtrang,
                           Loaive = a.Loaive,
                           Vethang = a.Vethang,
                           Giatien = a.Giatien,
                           Matuyen = a.Matuyen,
                           Tentuyen = db.Tuyenxes.Where(x => x.Matuyen == a.Matuyen).FirstOrDefault().Tentuyen ?? "Không xác định",
                       }).Where(xe => xe.Mave == mave).FirstOrDefault();
            return Json(new { success = true, data = _xe }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listVeXe = (from a in db.VeXes
                            select new VeXeDTO
                            {
                                Mave = a.Mave,
                                Ngayphathanh = a.Ngayphathanh,
                                Ngayhethan = a.Ngayhethan,
                                Tinhtrang = a.Tinhtrang,
                                Loaive = a.Loaive,
                                Vethang = a.Vethang,
                                Giatien = a.Giatien,
                                Matuyen = a.Matuyen,
                                Tentuyen = db.Tuyenxes.Where(x => x.Matuyen == a.Matuyen).FirstOrDefault().Tentuyen ?? "Không xác định",
                            }).ToList();
            var listTuyenXe = db.Tuyenxes.ToList();
            ViewBag.ListVeXe = listVeXe;
            ViewBag.ListTuyenXe = listTuyenXe;
            return View();
        }

        public ActionResult List()
        {
            var listVeXe = (from a in db.VeXes
                            select new VeXeDTO
                            {
                                Mave = db.CT_Hoadons.Where(x => x.Mave == a.Mave).FirstOrDefault().Mave,
                                Ngayphathanh = a.Ngayphathanh,
                                Ngayhethan = a.Ngayhethan,
                                /*NgayMua = db.Hoadons.Where(x => x.Ngaymua == a.Ngaymua).FirstOrDefault().Ngaymua.GetValueOrDefault(),*/
                                Tinhtrang = a.Tinhtrang,
                                Loaive = a.Loaive,
                                Vethang = a.Vethang,
                                Giatien = a.Giatien,
                                Matuyen = a.Matuyen,
                                Tentuyen = db.Tuyenxes.Where(x => x.Matuyen == a.Matuyen).FirstOrDefault().Tentuyen ?? "Không xác định",
                            }).ToList();
            return Json(new { success = true, data = listVeXe }, JsonRequestBehavior.AllowGet);
        }
    }
}