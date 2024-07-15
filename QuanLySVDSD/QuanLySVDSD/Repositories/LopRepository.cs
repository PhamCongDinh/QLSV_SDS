using NHibernate;
using NHibernate.Linq;
using QuanLySVDSD.Models.DTO;
using ISession = NHibernate.ISession;

namespace QuanLySVDSD.Repositories
{
    public class LopRepository : ILopRepository
    {
        private readonly ISession _db;
        private readonly ITransaction transaction;
        public LopRepository(ISessionFactory sessionFactory)
        {
            _db = sessionFactory.OpenSession();
            transaction = _db.BeginTransaction();
        }
        public async Task<Lop> Add(Lop Lop)
        {
            await _db.SaveAsync(Lop);
            transaction.Commit();
            return Lop;
        }

        public Task Delete(int LopId)
        {
            throw new NotImplementedException();
        }

        public Task<Lop> Get(int LopId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lop>> GetAll()
        {
            var lst = await _db.Query<Lop>().ToListAsync();
            return lst;
        }

        public async Task<Lop> getmaLop(string maLop)
        {
            var lop = await _db.Query<Lop>().Where(x => x.MaLop == maLop).FirstOrDefaultAsync();
            return lop;
        }

        public Task<Lop> Update(Lop Lop)
        {
            throw new NotImplementedException();
        }
    }
}
