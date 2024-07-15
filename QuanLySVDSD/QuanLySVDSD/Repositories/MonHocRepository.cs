using NHibernate;
using NHibernate.Linq;
using QuanLySVDSD.Models.DTO;
using ISession = NHibernate.ISession;

namespace QuanLySVDSD.Repositories
{
    public class MonHocRepository : IMonHocRepository
    {
        private readonly ISession _db;
        private readonly ITransaction transaction;
        public MonHocRepository(ISessionFactory sessionFactory)
        {
            _db = sessionFactory.OpenSession();
            transaction = _db.BeginTransaction();
        }
        public async Task<MonHoc> Add(MonHoc MonHoc)
        {
            await _db.SaveAsync(MonHoc);
            transaction.Commit();
            return MonHoc;
        }

        public Task Delete(int MonHocId)
        {
            throw new NotImplementedException();
        }

        public Task<MonHoc> Get(int MonHocId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MonHoc>> GetAll()
        {
            var lst = await _db.Query<MonHoc>().ToListAsync();
            return lst;
        }

        public async Task<MonHoc> getmaMonHoc(string maMonHoc)
        {
            var MonHoc = await _db.Query<MonHoc>().Where(x => x.MaMonHoc == maMonHoc).FirstOrDefaultAsync();
            return MonHoc;
        }

        public Task<MonHoc> Update(MonHoc MonHoc)
        {
            throw new NotImplementedException();
        }
    }
}
