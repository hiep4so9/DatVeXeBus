using QLXeBuyt.Models;
using QLXeBuyt.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace QLXeBuyt.Controllers
{
    public class TaiKhoanController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        [HttpPost]
        public ActionResult Save(Taikhoan req)
        {
            var _taikhoan = db.Taikhoans.Where(x => x.Id_Taikhoan == req.Id_Taikhoan).FirstOrDefault();
            _taikhoan.Email = req.Email;
            _taikhoan.Sodienthoai = req.Sodienthoai;
            _taikhoan.Code = req.Code;
            _taikhoan.Tinhtrang = req.Tinhtrang;
            _taikhoan.Sodu = req.Sodu;
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id_taikhoan)
        {
            var _taikhoan = db.Taikhoans.Where(x => x.Id_Taikhoan == id_taikhoan).FirstOrDefault();
            db.Taikhoans.DeleteOnSubmit(_taikhoan);
            db.SubmitChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindById(int id_taikhoan)
        {
            var _taikhoan = (from a in db.Taikhoans.Where(x => x.Id_Taikhoan == id_taikhoan)
                             select new TaiKhoanDTO { 
                                Id_Taikhoan = a.Id_Taikhoan,
                                Tentaikhoan = a.Tentaikhoan,
                                Matkhau = a.Matkhau,
                                Email = a.Email,
                                Sodienthoai = a.Sodienthoai,
                                Code = a.Code.GetValueOrDefault(),
                                Tinhtrang = a.Tinhtrang,
                                Sodu = (double)a.Sodu.GetValueOrDefault(),
                                Maloai = a.Maloai
                             }).FirstOrDefault();
            return Json(new { success = true, data = _taikhoan }, JsonRequestBehavior.AllowGet);
        }

        // GET: TaiKhoan
        public ActionResult Index()
        {
            ViewBag.ListTaiKhoan = db.Taikhoans.ToList();
            return View();
        }

        public ActionResult List()
        {
            var _taikhoan = (from a in db.Taikhoans select new TaiKhoanDTO
                             {
                                 Id_Taikhoan = a.Id_Taikhoan,
                                 Tentaikhoan = a.Tentaikhoan,
                                 Matkhau = a.Matkhau,
                                 Email = a.Email,
                                 Sodienthoai = a.Sodienthoai,
                                 Code = a.Code.GetValueOrDefault(),
                                 Tinhtrang = a.Tinhtrang,
                                 Sodu = (double)a.Sodu.GetValueOrDefault(),
                                 Maloai = a.Maloai
                             }).ToList();
            return Json(new { success = true, data = _taikhoan}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(Taikhoan req)
        {
            var check = db.Taikhoans.Where(x => x.Tentaikhoan == req.Tentaikhoan && x.Matkhau == req.Matkhau);
            if (check.Any())
            {
                var _taikhoan = (from a in db.Taikhoans.Where(x => x.Id_Taikhoan == check.FirstOrDefault().Id_Taikhoan)
                                 select new TaiKhoanDTO
                                 {
                                     Id_Taikhoan = a.Id_Taikhoan,
                                     Tentaikhoan = a.Tentaikhoan,
                                     Matkhau = a.Matkhau,
                                     Email = a.Email,
                                     Sodienthoai = a.Sodienthoai,
                                     Code = a.Code.GetValueOrDefault(),
                                     Tinhtrang = a.Tinhtrang,
                                     Sodu = (double)a.Sodu.GetValueOrDefault(),
                                     Maloai = a.Maloai
                                 }).FirstOrDefault();
                return Json(new { success = true, data = _taikhoan, token = createToken(_taikhoan.Tentaikhoan) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, data = req }, JsonRequestBehavior.AllowGet);
            }
        }

        public static string createToken(string Username)
        {
            //Đặt thời gian
            DateTime issuedAt = DateTime.UtcNow;
            //đặt thời gian hết hạn token
            DateTime expires = DateTime.UtcNow.AddDays(10);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in

            var userIdentity = new ClaimsIdentity("Identity");
            userIdentity.Label = "Identity";
            userIdentity.AddClaim(new Claim(ClaimTypes.Name, Username));
            userIdentity.AddClaim(new Claim("Username", Username));
            //userIdentity.AddClaim(new Claim("Category", Category));
            //userIdentity.HasClaim(ClaimTypes.Role, Category);
            var claims = new List<Claim>();

            var identity = new ClaimsPrincipal(userIdentity);
            Thread.CurrentPrincipal = identity;
            //string sec = EncryptCode;
            string sec = "088881139703564148785";
            //string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1" + Category;
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://unisoft.edu.vn/", audience: "http://unisoft.edu.vn/",
                        subject: userIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}