using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Repositories
{
    public interface IDiemRepository
    {
        public Task<Diem> Add(Diem Diem);
        public Task<Diem> Update(Diem Diem);
        public Task Delete(int DiemId);
        public Task<List<Diem>> GetAll();
        public Task<Diem> Get(int DiemId);
        public Task<Diem> Check(int monhocId, int sinhvienId);
    }
}
