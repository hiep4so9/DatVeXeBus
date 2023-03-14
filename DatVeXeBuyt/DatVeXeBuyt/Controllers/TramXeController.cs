using QLXeBuyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class TramXeController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Tramxe req)
        {
           
            if (req.Matram > 0)
            {
                var _tramxe = db.Tramxes.Where(x => x.Matram == req.Matram).FirstOrDefault();
                _tramxe.Tentram = req.Tentram;
                _tramxe.Tentuyenduong = req.Tentuyenduong;
                _tramxe.Toado = req.Toado;
                _tramxe.Manhung = req.Manhung;
                db.SubmitChanges();
                return Json(new { success = true, data = _tramxe }, JsonRequestBehavior.AllowGet);
            }
            db.Tramxes.InsertOnSubmit(req);
            db.SubmitChanges();
            return Json(new { success = true, data = req }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int matram)
        {
            var _tramxe = db.Tramxes.Where(M => M.Matram == matram).FirstOrDefault();
            db.Tramxes.DeleteOnSubmit(_tramxe);
            db.SubmitChanges();
            return Json(new { success = true, data = _tramxe }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int matram)
        {
            var _tramxe = db.Tramxes.Where(M => M.Matram == matram).FirstOrDefault();
            return Json(new { success = true, data = _tramxe }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var listTramXe = db.Tramxes.ToList();
            ViewBag.ListTramXe = listTramXe;
            return View();
        }
    }
}