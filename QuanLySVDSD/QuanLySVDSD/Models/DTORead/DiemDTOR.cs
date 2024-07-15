using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Models.DTORead
{
    public class DiemDTOR
    {
        public virtual int Id { get; set; }
        public virtual decimal DiemQuaTrinh { get; set; }
        public virtual decimal DiemThanhPhan { get; set; }
        public virtual SinhVien SinhVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
