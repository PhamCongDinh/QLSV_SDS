using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Repositories
{
    public interface ILopRepository
    {
        public Task<Lop> Add(Lop Lop);
        public Task<Lop> Update(Lop Lop);
        public Task Delete(int LopId);
        public Task<List<Lop>> GetAll();
        public Task<Lop> Get(int LopId);
        public Task<Lop> getmaLop(string maLop);
    }
}
