namespace QLSVDapperSDS.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public int? Id_Lop { get; set; }
        public int? Id_Khoas { get; set; }
        public List<Diem> diems { get; set; }
    }
}
