using NHibernate;
using NHibernate.Linq;
using QuanLySVDSD.Models.DTO;
using ISession = NHibernate.ISession;

namespace QuanLySVDSD.Repositories
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly ISession _db;
        private readonly ITransaction transaction;
        public SinhVienRepository(ISessionFactory sessionFactory)
        {
            _db = sessionFactory.OpenSession();
            transaction = _db.BeginTransaction();
        }
        public async Task<SinhVien> Add(SinhVien entity)
        {
            await _db.SaveAsync(entity);
            transaction.Commit();
            return entity;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SinhVien>> GetAll()
        {
            var lstSV = await _db.Query<SinhVien>().ToListAsync();
            return lstSV;
        }

        public Task<SinhVien> getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SinhVien> Update(SinhVien entity)
        {
            throw new NotImplementedException();
        }
    }
}
