namespace QLSVDapperSDS.Models
{
    public class Lop
    {
        public  int Id { get; set; }
        public  string MaLop { get; set; }
        public  string TenLop { get; set; }
        public List<SinhVien>? SinhVien { get; set; }
    }
}
