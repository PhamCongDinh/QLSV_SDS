using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Repositories
{
    public interface IKhoasRepository
    {
        public Task<Khoas> Add(Khoas khoas);
        public Task<Khoas> Update(Khoas khoas);
        public Task Delete(int khoasId);
        public Task<List<Khoas>> GetAll();
        public Task<Khoas> Get(int khoasId);
        public Task<Khoas> getmakhoas(string makhoas);
    }
}
