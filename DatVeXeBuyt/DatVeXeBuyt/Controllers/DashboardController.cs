using QLXeBuyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class DashboardController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        // GET: DashBoard
        public ActionResult Index()
        {
            var totalIncome = 0;
            ViewBag.CountKhachHang = db.Khachhangs.Count();
            ViewBag.CountTuyenXe = db.Tuyenxes.Count();
            ViewBag.CountXe = db.Xes.Count();
            ViewBag.CountHoaDon = db.CT_Hoadons.Count();
            ViewBag.ListTuyenXe = db.Tuyenxes.ToList();
            var lstMaVe = db.CT_Hoadons.Select(x => x.Mave).Distinct();
            lstMaVe.ToList().ForEach(x => { 
                if (db.VeXes.Select(v => v.Mave).ToList().Contains(x))
                {
                    totalIncome += (int)db.VeXes.Where(m => m.Mave == x).FirstOrDefault().Giatien;
                }
            });
            ViewBag.TotalIncome = totalIncome;
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
    }
}