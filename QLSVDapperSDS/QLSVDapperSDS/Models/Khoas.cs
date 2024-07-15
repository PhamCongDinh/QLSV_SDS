namespace QLSVDapperSDS.Models
{
    public class Khoas
    {
        public  int Id { get; set; }
        public  string MaKhoas { get; set; }
        public  string TenKhoas { get; set; }
        public List<SinhVien>? SinhVien { get; set; }
    }
}
