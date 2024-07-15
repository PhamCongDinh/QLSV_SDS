using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Models.DTORespose;

namespace QLSVDapperSDS.Reposirories
{
    public interface IDiemRepository
    {
        public Task<Diem> addDiem(DangKyMonHoc dky);
        public Task<Diem> UpdateDiem(int id, DiemReq diemReq);
        public Task<List<Diem>> getDiemList();
        public Task<Diem> Check(int id_sv, int id_monhoc);
    }
}
