using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Reposirories;
using QLSVDapperSDS.Models.DTORespose;

namespace QLSVDapperSDS.Services
{
    public class DiemService
    {
        private readonly IGenericRepository<SinhVien, SinhVienReq> _svrepo;
        private readonly IGenericRepository<MonHoc, MonHocReq> _monhocprepo;
        private readonly IDiemRepository diemRepository;
        public DiemService(IGenericRepository<SinhVien, SinhVienReq> svrepo, IGenericRepository<MonHoc, MonHocReq> monhocprepo, IDiemRepository diemRepository)
        {
            _svrepo = svrepo;
            _monhocprepo = monhocprepo;
            this.diemRepository = diemRepository;
        }
        public async Task<Diem> DangkyMH(DangKyMonHoc dangKyMonHoc)
        {
            var ktra = await diemRepository.Check(dangKyMonHoc.Id_SinhVien,dangKyMonHoc.Id_MonHoc);
            if (ktra == null)
            {
                return await diemRepository.addDiem(dangKyMonHoc);
            }
            else
            {
                throw new Exception("Bạn đã đăng ký môn học này rồi");
            }
        }
        public async Task<List<DiemRes>> getdiembysv(int svid)
        {
            var lstsv =await _svrepo.GetAllAsync();
            var lstmh = await _monhocprepo.GetAllAsync();
            var lstdiem = await diemRepository.getDiemList();
            var ds = (from sv in lstsv
                     join d in lstdiem on sv.Id equals d.Id_SinhVien
                     join mh in lstmh on d.Id_MonHoc equals mh.Id
                     where sv.Id == svid
                     select new DiemRes
                     {
                         Id = d.Id,
                         SinhVien = sv,
                         MonHoc = mh,
                         DiemQuaTrinh = d.DiemQuaTrinh,
                         DiemThanhPhan = d.DiemThanhPhan,
                     }).ToList();
            return ds;

        }
        public async Task<DiemRes> getdiembyid(int id)
        {
            var lstsv = await _svrepo.GetAllAsync();
            var lstmh = await _monhocprepo.GetAllAsync();
            var lstdiem = await diemRepository.getDiemList();
            var ds = (from sv in lstsv
                      join d in lstdiem on sv.Id equals d.Id_SinhVien
                      join mh in lstmh on d.Id_MonHoc equals mh.Id
                      where d.Id == id
                      select new DiemRes
                      {
                          Id = d.Id,
                          SinhVien = sv,
                          MonHoc = mh,
                          DiemQuaTrinh = d.DiemQuaTrinh,
                          DiemThanhPhan = d.DiemThanhPhan,
                      }).FirstOrDefault();
            return ds;

        }

        public async Task<Diem> UpdateDiem(int id, DiemReq diemReq)
        {
            Diem update = await diemRepository.UpdateDiem(id,diemReq);
            return update;
        }
        
    }
}
