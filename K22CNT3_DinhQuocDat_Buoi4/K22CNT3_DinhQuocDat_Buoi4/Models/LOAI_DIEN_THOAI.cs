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
    
    public partial class LOAI_DIEN_THOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAI_DIEN_THOAI()
        {
            this.DIEN_THOAI = new HashSet<DIEN_THOAI>();
        }
    
        public int ID { get; set; }
        public string MaLoaiDienThoai { get; set; }
        public string TheLoaiDienThoai { get; set; }
        public Nullable<byte> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEN_THOAI> DIEN_THOAI { get; set; }
    }
}