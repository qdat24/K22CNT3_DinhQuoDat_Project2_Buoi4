//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT3_DinhQuocDat_Buoi4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HOA_DON
    {
        public int ID { get; set; }
        public Nullable<int> HoaDonID { get; set; }
        public Nullable<int> DienThoaiID { get; set; }
        public Nullable<int> SoLuongMua { get; set; }
        public Nullable<double> DonGiaMua { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<byte> TrangThai { get; set; }
    
        public virtual DIEN_THOAI DIEN_THOAI { get; set; }
        public virtual HOA_DON HOA_DON { get; set; }
    }
}
