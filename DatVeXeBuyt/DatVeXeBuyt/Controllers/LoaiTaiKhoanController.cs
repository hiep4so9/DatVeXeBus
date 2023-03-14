using QLXeBuyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class LoaiTaiKhoanController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Loaitaikhoan req)
        {
            db.Loaitaikhoans.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true, data = req }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id_Loaitaikhoan)
        {
            var _loaitk = db.Loaitaikhoans.Where(M => M.Id_Loaitaikhoan == id_Loaitaikhoan).FirstOrDefault();
            db.Loaitaikhoans.DeleteOnSubmit(_loaitk);
            db.SubmitChanges();
            return Json(new { success = true, data = _loaitk }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listLoaiTK = db.Loaitaikhoans.ToList();
            ViewBag.ListLoaiTK = listLoaiTK;
            return View();
        }
    }
}