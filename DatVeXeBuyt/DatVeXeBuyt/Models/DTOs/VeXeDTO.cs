using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXeBuyt.Models.DTOs
{
    public class VeXeDTO : VeXe
    {
        public string Tentuyen { get; set; }
        public int Id_Taikhoan { get; set; }
        
        public DateTime NgayMua { get; set; }
    }
}