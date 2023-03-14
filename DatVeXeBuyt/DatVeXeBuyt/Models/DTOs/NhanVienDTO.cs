using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXeBuyt.Models.DTOs
{
    public class NhanVienDTO: Nhanvien
    {
        public Taikhoan Taikhoan { get; set; }
        public string Tentaikhoan { get; set; }
        public string Tengioitinh { get; set; }
    }
}