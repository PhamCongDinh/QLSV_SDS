using NHibernate;
using NHibernate.Linq;
using QuanLySVDSD.Models.DTO;
using ISession = NHibernate.ISession;

namespace QuanLySVDSD.Repositories
{
    public class KhoasRepository : IKhoasRepository
    {
        private readonly ISession _db;
        private readonly ITransaction transaction;
        public KhoasRepository(ISessionFactory sessionFactory)
        {
            _db = sessionFactory.OpenSession();
            transaction = _db.BeginTransaction();
        }
        public async Task<Khoas> Add(Khoas khoas)
        {
            await _db.SaveAsync(khoas);
            transaction.Commit();
            return khoas;
        }

        public Task Delete(int khoasId)
        {
            throw new NotImplementedException();
        }

        public async Task<Khoas> Get(int khoasId)
        {
            var khoas = await _db.Query<Khoas>().Where(x=>x.Id==khoasId).FirstOrDefaultAsync();
            return khoas;
        }

        public async Task<List<Khoas>> GetAll()
        {
            var lst = await _db.Query<Khoas>().ToListAsync();
            return lst;
        }

        public async Task<Khoas> getmakhoas(string makhoas)
        {
            var khoas = await _db.Query<Khoas>().Where(x => x.MaKhoas == makhoas).FirstOrDefaultAsync();
            return khoas;
        }

        public async Task<Khoas> Update(Khoas khoas)
        {
            await _db.SaveOrUpdateAsync(khoas);
            transaction.Commit();
            return khoas;
        }
    }
}
