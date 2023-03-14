using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXeBuyt.Models.DTOs
{
    public class TuyenxeDTO
    {
        public int MaTuyen { get; set; }
        public int TuyenSo { get; set; }
        public string TenTuyen { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string LuotDi { get; set; }
        public string LuotVe { get; set; }
        public string LoaiTuyen { get; set; }
        public string ThoiGianChay { get; set; }
        public string GianCachTuyen { get; set; }
        public int SoChuyen { get; set; }
        public decimal Giatien { get; set; }

    }
}
