using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXeBuyt.Models.DTOs
{
    public class HoaDonDTO : Hoadon
    {
        public string Tenkhachhang { get; set; }
        public string Tentrangthai { get; set; }
    }
}