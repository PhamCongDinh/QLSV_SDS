using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Models.DTORead
{
    public class SinhVienDTOR
    {
        public virtual int Id { get; set; }
        public virtual string MaSinhVien { get; set; }
        public virtual string TenSinhVien { get; set; }
        public virtual int GioiTinh { get; set; }
        public virtual DateTime NgayThangNamSinh { get; set; }
        public virtual Lop Lop { get; set; }
        public virtual Khoas Khoa { get; set; }
    }
}
