using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Repositories
{
    public interface ISinhVienRepository
    {
        public Task<SinhVien> Add(SinhVien entity);
        public Task<SinhVien> Update(SinhVien entity);
        public Task Delete(int id);

        public Task<List<SinhVien>> GetAll();
        public Task<SinhVien> getbyid(int id);
    }
}
