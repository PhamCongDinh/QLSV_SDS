namespace QuanLySVDSD.Models.DTO
{
    public class SinhVien
    {
        public virtual int Id { get; set; }
        public virtual string MaSinhVien { get; set; }
        public virtual string TenSinhVien { get;set; }
        public virtual int GioiTinh { get; set; }
        public virtual DateTime NgayThangNamSinh { get; set; }
        public virtual int? Id_Lop {  get; set; }
        public virtual int? Id_Khoas { get; set; }
    }
}
