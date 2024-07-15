using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Reposirories;

namespace QLSVDapperSDS.Services
{
    public class MonHocService
    {
        private readonly IGenericRepository<MonHoc, MonHocReq> _monhocprepo;
        public MonHocService(IGenericRepository<MonHoc, MonHocReq> monhocprepo)
        {
            _monhocprepo = monhocprepo;
        }

        public async Task<MonHoc> AddMonHocAsync(MonHocReq monhocreq)
        {
            var check = await _monhocprepo.GetByMaAsync(monhocreq.MaMonHoc);
            if (check != null)
            {
                throw new Exception("Mã lớp này đã có");
            }
            else
            {
                return await _monhocprepo.AddAsync(monhocreq);
            }

        }
    }
}
