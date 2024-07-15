using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Reposirories;

namespace QLSVDapperSDS.Services
{
    public class LopService
    {
        private readonly IGenericRepository<Lop, LopReq> _loprepo;
        public LopService(IGenericRepository<Lop,LopReq> loprepo)
        {
            _loprepo = loprepo;
        }
        public async Task<Lop> AddLopAsync(LopReq lopreq)
        {
            var check = await _loprepo.GetByMaAsync(lopreq.MaLop);
            if (check != null) {
                throw new Exception("Mã lớp này đã có");
            }
            else
            {
                return await _loprepo.AddAsync(lopreq);
            }

        }
        public async Task<Lop> UpdateLopAsync(int id, LopReq lopreq)
        {
            var checkname = await _loprepo.GetByIdAsync(id);
            if(lopreq.MaLop != checkname.MaLop)
            {
                var check = await _loprepo.GetByMaAsync(lopreq.MaLop);
                if (check != null)
                {
                    throw new Exception("Mã lớp này đã có");
                }
                
            }
            return await _loprepo.UpdateAsync(id, lopreq);


        }

    }
}
