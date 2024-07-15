namespace QuanLySVDSD.Models.DTO
{
    public class Diem
    {
        public virtual int Id { get; set; }
        public virtual decimal DiemQuaTrinh {  get; set; }
        public virtual decimal DiemThanhPhan {  get; set; }
        public virtual int Id_SinhVien {  get; set; }
        public virtual int Id_MonHoc {  get; set; }
    }
}
