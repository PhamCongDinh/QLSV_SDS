using NHibernate;
using NHibernate.Linq;
using QuanLySVDSD.Models.DTO;
using ISession = NHibernate.ISession;

namespace QuanLySVDSD.Repositories
{
    public class DiemRepository : IDiemRepository
    {
        private readonly ISession _db;
        private readonly ITransaction transaction;
        public DiemRepository(ISessionFactory sessionFactory)
        {
            _db = sessionFactory.OpenSession();
            transaction = _db.BeginTransaction();
        }
        public async Task<Diem> Add(Diem Diem)
        {
            await _db.SaveAsync(Diem);
            transaction.Commit();
            return Diem;
        }

        public async Task<Diem> Check(int monhocId, int sinhvienId)
        {
            var check = await _db.Query<Diem>().Where(x=>x.Id_MonHoc==monhocId && x.Id_SinhVien==sinhvienId).FirstOrDefaultAsync();
            return check;
        }

        public Task Delete(int DiemId)
        {
            throw new NotImplementedException();
        }

        public async Task<Diem> Get(int DiemId)
        {
            Diem diem = await _db.Query<Diem>().Where(x=>x.Id==DiemId).FirstOrDefaultAsync();
            return diem;
        }

        public async Task<List<Diem>> GetAll()
        {
            var lst = await _db.Query<Diem>().ToListAsync();
            return lst;
        }

        public async Task<Diem> Update(Diem Diem)
        {
            await _db.SaveOrUpdateAsync(Diem);
            transaction.Commit();
            return Diem;
        }
    }
}
