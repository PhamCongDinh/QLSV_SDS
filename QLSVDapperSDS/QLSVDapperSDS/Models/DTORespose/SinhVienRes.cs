namespace QLSVDapperSDS.Models.DTORespose
{
    public class SinhVienRes
    {
        public int Id { get; set; }
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public Lop Lops {  get; set; }
        public Khoas Khoas { get; set; }

    }
}
