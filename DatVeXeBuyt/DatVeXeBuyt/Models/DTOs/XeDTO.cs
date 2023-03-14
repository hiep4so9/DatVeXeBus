using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXeBuyt.Models.DTOs
{
    public class XeDTO : Xe
    {
        public int Maxe { get; set; }

        public String Tentuyen { get; set; }
    }
}