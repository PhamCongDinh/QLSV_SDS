namespace QLSVDapperSDS.Models.DTORespose
{
    public class DiemRes
    {
        public int Id {  get; set; }
        public SinhVien SinhVien { get; set; }
        public MonHoc MonHoc { get; set; }
        public decimal DiemQuaTrinh {  get; set; }
        public decimal DiemThanhPhan {  get; set; }
    }
}
