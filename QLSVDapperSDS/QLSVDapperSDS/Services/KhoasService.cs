using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Reposirories;

namespace QLSVDapperSDS.Services
{
    public class KhoasService
    {
        private readonly IGenericRepository<Khoas, KhoasReq> _khoasrepo;
        public KhoasService(IGenericRepository<Khoas, KhoasReq> khoasrepo)
        {
            _khoasrepo = khoasrepo;
        }
        public async Task<Khoas> AddLopAsync(KhoasReq khoasReq)
        {
            var check = await _khoasrepo.GetByMaAsync(khoasReq.MaKhoas);
            if (check != null) 
            {
                throw new Exception("Mã Khóa này đã có");
            }
            else
            {
                return await _khoasrepo.AddAsync(khoasReq);
            }

        }
        public async Task<Khoas> UpdateLopAsync(int id, KhoasReq khoasReq)
        {
            var checkname = await _khoasrepo.GetByIdAsync(id);
            if (khoasReq.MaKhoas != checkname.MaKhoas)
            {
                var check = await _khoasrepo.GetByMaAsync(khoasReq.MaKhoas);
                if (check != null)
                {
                    throw new Exception("Mã khóa này đã có");
                }

            }
            return await _khoasrepo.UpdateAsync(id, khoasReq);


        }
    }
}
