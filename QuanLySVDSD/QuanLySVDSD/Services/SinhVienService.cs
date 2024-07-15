using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Models.DTORead;
using QuanLySVDSD.Repositories;

namespace QuanLySVDSD.Services
{
    public class SinhVienService
    {
        private readonly IKhoasRepository khoasRepository;
        private readonly ISinhVienRepository sinhVienRepository;
        private readonly ILopRepository lopRepository;
        public SinhVienService(IKhoasRepository khoasRepository, ISinhVienRepository sinhVienRepository, ILopRepository lopRepository)
        {
            this.khoasRepository = khoasRepository;
            this.sinhVienRepository = sinhVienRepository;
            this.lopRepository = lopRepository;
        }
        public async Task<SinhVien> AddSV(SinhVien sinhVien)
        {
            await sinhVienRepository.Add(sinhVien);
            return sinhVien;
        }
        public async Task<List<SinhVienDTOR>> getall()
        {
            var khoas = await khoasRepository.GetAll();
            var lops = await lopRepository.GetAll();
            var sinhviens = await sinhVienRepository.GetAll();
            var lst = (from sv in sinhviens
                      join khoa in khoas on sv.Id_Khoas equals khoa.Id into khoagrop
                      from khoa in khoagrop.DefaultIfEmpty()
                      join lop in lops on sv.Id_Lop equals lop.Id into loprop
                      from lop in loprop.DefaultIfEmpty()
                      select new SinhVienDTOR
                      {
                          Id = sv.Id,
                          MaSinhVien = sv.MaSinhVien,
                          TenSinhVien = sv.TenSinhVien,
                          GioiTinh = sv.GioiTinh,
                          NgayThangNamSinh = sv.NgayThangNamSinh,
                          Lop = lop,
                          Khoa = khoa
                      }).ToList();
            return lst;
        }
        public async Task<SinhVienDTOR> getbyid(int id)
        {
            var khoas = await khoasRepository.GetAll();
            var lops = await lopRepository.GetAll();
            var sinhviens = await sinhVienRepository.GetAll();
            var sinhvien = (from sv in sinhviens
                       join khoa in khoas on sv.Id_Khoas equals khoa.Id into khoagrop
                       from khoa in khoagrop.DefaultIfEmpty()
                       join lop in lops on sv.Id_Lop equals lop.Id into loprop
                       from lop in loprop.DefaultIfEmpty()
                       where sv.Id == id
                       select new SinhVienDTOR
                       {
                           Id = sv.Id,
                           MaSinhVien = sv.MaSinhVien,
                           TenSinhVien = sv.TenSinhVien,
                           GioiTinh = sv.GioiTinh,
                           NgayThangNamSinh = sv.NgayThangNamSinh,
                           Lop = lop,
                           Khoa = khoa
                       }).FirstOrDefault();
            return sinhvien;
        }
    }
}
