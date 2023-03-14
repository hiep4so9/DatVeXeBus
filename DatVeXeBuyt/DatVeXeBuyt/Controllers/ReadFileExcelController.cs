using OfficeOpenXml;
using QLXeBuyt.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class ReadFileExcelController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        public ActionResult UploadTuyenXeToEpPlus(string fileName, string soTuyen, string soChuyen)
        {
            try
            {
                // path to your excel file
                var FilePath = Server.MapPath("~/FileImport/" + fileName);
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(FilePath)))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[soChuyen];
                    var totalRows = workSheet.Dimension.Rows;
                    var listTuyen = db.Tuyenxes.Where(x => x.Sochuyen == Int16.Parse(soChuyen) && x.Tuyenso == Int16.Parse(soTuyen)).ToList();
                    if (listTuyen.Count > 0)
                    {
                        db.Tuyenxes.DeleteAllOnSubmit(listTuyen);
                        db.SubmitChanges();
                    }

                    for (int i = 2; i < totalRows; i++)
                    {
                        if (workSheet.Cells[i, 1].Value == null)
                        {
                            break;
                        }
                        Random rnd = new Random();
                        Tuyenxe tx = new Tuyenxe();
                        tx.Tuyenso = Int16.Parse(workSheet.Cells[i, 1].Value.ToString());
                        tx.Tentuyen = /*"Số chuyến " + soChuyen;*/ workSheet.Cells[i, 2].Value.ToString().Trim();
                        tx.Thoigianbatdau = DateTime.Now;
                        tx.Thoigianketthuc = DateTime.Now;
                        tx.Loaituyen = workSheet.Cells[i, 4].Value.ToString();
                        tx.Thoigianchay = workSheet.Cells[i, 5].Value.ToString();
                        tx.Giancachtuyen = workSheet.Cells[i, 6].Value.ToString();
                        tx.Sochuyen = Int16.Parse(workSheet.Cells[i, 7].Value.ToString());
                        tx.Luotdi = workSheet.Cells[i, 8].Value.ToString().Trim();
                        tx.Luotve = workSheet.Cells[i, 9].Value.ToString().Trim() ?? "";


                        db.Tuyenxes.InsertOnSubmit(tx);
                        db.SubmitChanges();
                    }
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
