using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT3_DinhQuocDat_Buoi4.Models
{
    public class DQDCartItem
    {
        public int ID { get; set; }
        public string TenDienThoai { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuongMua { get; set; }
        public float DonGiaMua { get; set; }
        public float ThanhTien { get; set; }
    }
}