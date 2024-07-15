using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Models.DTOCreate;
using QuanLySVDSD.Models.DTORead;
using QuanLySVDSD.Models.DTOUpdate;
using QuanLySVDSD.Repositories;

namespace QuanLySVDSD.Services
{
    public class DiemService
    {
        private readonly IDiemRepository _DiemRepository;
        private readonly ISinhVienRepository _SVienRepository;
        private readonly IMonHocRepository _MonHocRepository;
        public DiemService(IDiemRepository DiemRepository, IMonHocRepository monHocRepository, ISinhVienRepository sinhVienRepository)
        {
            _DiemRepository = DiemRepository;
            _MonHocRepository = monHocRepository;
            _SVienRepository = sinhVienRepository;
        }
        public async Task<List<Diem>> getall()
        {
            var lst = await _DiemRepository.GetAll();
            return lst;
        }
        public async Task<Diem> AddDiem(DiemDTOCr diem)
        {
            Diem check = await _DiemRepository.Check(diem.Id_MonHoc, diem.Id_SinhVien);
            if (check == null)
            {
                Diem dky = new Diem();
                dky.Id_MonHoc = diem.Id_MonHoc;
                dky.Id_SinhVien = diem.Id_SinhVien;
                await _DiemRepository.Add(dky);
                return dky;
            }
            else
            {
                throw new Exception("bạn đã đăng ký môn học này rồi hãy kiểm tra danh sách môn đã đăng");
            }
        }

        public async Task<Diem> Update(DiemDTOUp diem)
        {
            Diem filter = await _DiemRepository.Get(diem.Id);
            if (filter == null)
            {
                throw new Exception("Can not found");
            }
            else
            {
                filter.DiemQuaTrinh = diem.DiemQuaTrinh;
                filter.DiemThanhPhan = diem.DiemThanhPhan;
                await _DiemRepository.Update(filter);
                return filter;
            }
        }
        public async Task<DiemDTOR> getdiembyid(int id)
        {
            var lstd = await _DiemRepository.GetAll();
            var lstsv= await _SVienRepository.GetAll();
            var lstmh = await _MonHocRepository.GetAll();
            var diemdetail = (from sv in lstsv
                             join d in lstd on sv.Id equals d.Id_SinhVien
                             join mh in lstmh on d.Id_MonHoc equals mh.Id
                             where d.Id == id
                             select new DiemDTOR
                             {
                                 Id = d.Id,
                                 SinhVien = sv,
                                 MonHoc = mh,
                                 DiemQuaTrinh = d.DiemQuaTrinh,
                                 DiemThanhPhan = d.DiemThanhPhan
                             }).FirstOrDefault();
            return diemdetail;
        }
        public async Task<List<DiemDTOR>> getdiembySVid(int id)
        {
            var lstd = await _DiemRepository.GetAll();
            var lstsv = await _SVienRepository.GetAll();
            var lstmh = await _MonHocRepository.GetAll();
            var diemdetail = (from sv in lstsv
                              join d in lstd on sv.Id equals d.Id_SinhVien
                              //from d in dgrop.DefaultIfEmpty()
                              join mh in lstmh on d.Id_MonHoc equals mh.Id
                              where sv.Id == id
                              select new DiemDTOR
                              {
                                  Id = d.Id,
                                  SinhVien = sv,
                                  MonHoc = mh,
                                  DiemQuaTrinh = d.DiemQuaTrinh,
                                  DiemThanhPhan = d.DiemThanhPhan
                              }).ToList();
            return diemdetail;
        }
    }
}
