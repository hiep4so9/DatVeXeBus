using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXeBuyt.Models.DTOs
{
    public class TaiKhoanDTO : Khachhang
    {
        public string Tentaikhoan { get; set; }
        public string Matkhau { get; set; }
        public string Email { get; set; }
        public string Sodienthoai { get; set; }
        public int Code { get; set; }
        public string Tinhtrang { get; set; }
        public double Sodu { get; set; }
        public string Maloai { get; set; }
    }
}