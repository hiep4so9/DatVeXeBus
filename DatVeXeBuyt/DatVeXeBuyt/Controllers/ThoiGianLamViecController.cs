using QLXeBuyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class ThoiGianLamViecController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Thoigianlamviec req)
        {
            db.Thoigianlamviecs.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true, data = req }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id_thoigianlamviec)
        {
            var _tgian = db.Thoigianlamviecs.Where(M => M.Id_Thoigianlamviec == id_thoigianlamviec).FirstOrDefault();
            db.Thoigianlamviecs.DeleteOnSubmit(_tgian);
            db.SubmitChanges();
            return Json(new { success = true, data = _tgian }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listTgian = db.Thoigianlamviecs.ToList();
            ViewBag.ListThoiGianLamViec = listTgian;
            return View();
        }
    }
}