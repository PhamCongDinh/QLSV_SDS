using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Reposirories;
using QLSVDapperSDS.Models.DTORespose;

namespace QLSVDapperSDS.Services
{
    public class SinhVienService
    {
        private readonly IGenericRepository<Khoas, KhoasReq> _khoasrepo;
        private readonly IGenericRepository<Lop, LopReq> _loprepo;
        private readonly IGenericRepository<SinhVien, SinhVienReq> _svrepo;
        public SinhVienService(IGenericRepository<Khoas, KhoasReq> khoasrepo, IGenericRepository<Lop, LopReq> loprepo, IGenericRepository<SinhVien, SinhVienReq> svrepo)
        {
            _khoasrepo = khoasrepo;
            _loprepo = loprepo;
            _svrepo = svrepo;
        }
        public async Task<SinhVien> AddSinhVienAsync(SinhVienReq svReq)
        {
            var check = await _svrepo.GetByMaAsync(svReq.MaSinhVien);
            if (check != null)
            {
                throw new Exception("Mã sinh viên này đã có");
            }
            else
            {
                return await _svrepo.AddAsync(svReq);
            }

        }
        public async Task<SinhVien> UpdateSinhVienAsync(int id, SinhVienReq svReq)
        {
            var checkname = await _svrepo.GetByIdAsync(id);
            if (svReq.MaSinhVien != checkname.MaSinhVien)
            {
                var check = await _svrepo.GetByMaAsync(svReq.MaSinhVien);
                if (check != null)
                {
                    throw new Exception("Mã khóa này đã có");
                }

            }
            return await _svrepo.UpdateAsync(id, svReq);
        }
        public async Task<List<SinhVienRes>> GetAll()
        {
            var sinhviens = await _svrepo.GetAllAsync();
            var lops = await _loprepo.GetAllAsync();
            var khoas = await _khoasrepo.GetAllAsync();
            var dsSV = (from sv in sinhviens
                        join khoa in khoas on sv.Id_Khoas equals khoa.Id into khoagrop
                        from khoa in khoagrop.DefaultIfEmpty()
                        join lop in lops on sv.Id_Lop equals lop.Id into loprop
                        from lop in loprop.DefaultIfEmpty()
                        select new SinhVienRes
                        {
                            Id = sv.Id,
                            MaSinhVien = sv.MaSinhVien,
                            TenSinhVien = sv.TenSinhVien,
                            GioiTinh = sv.GioiTinh,
                            NgayThangNamSinh = sv.NgayThangNamSinh,
                            Lops = lop,
                            Khoas = khoa
                        }).ToList();
            return dsSV;
        }
        public async Task<SinhVienRes> Getbyid(int id)
        {
            var sinhviens = await _svrepo.GetAllAsync();
            var lops = await _loprepo.GetAllAsync();
            var khoas = await _khoasrepo.GetAllAsync();
            var dsSV = (from sv in sinhviens
                        join khoa in khoas on sv.Id_Khoas equals khoa.Id into khoagrop
                        from khoa in khoagrop.DefaultIfEmpty()
                        join lop in lops on sv.Id_Lop equals lop.Id into loprop
                        from lop in loprop.DefaultIfEmpty()
                        where sv.Id == id
                        select new SinhVienRes
                        {
                            Id = sv.Id,
                            MaSinhVien = sv.MaSinhVien,
                            TenSinhVien = sv.TenSinhVien,
                            GioiTinh = sv.GioiTinh,
                            NgayThangNamSinh = sv.NgayThangNamSinh,
                            Lops = lop,
                            Khoas = khoa
                        }).FirstOrDefault();
            return dsSV;
        }
    }
}
