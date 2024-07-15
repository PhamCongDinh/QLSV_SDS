using QuanLySVDSD.Models.DTO;

namespace QuanLySVDSD.Repositories
{
    public interface IMonHocRepository
    {
        public Task<MonHoc> Add(MonHoc MonHoc);
        public Task<MonHoc> Update(MonHoc MonHoc);
        public Task Delete(int MonHocId);
        public Task<List<MonHoc>> GetAll();
        public Task<MonHoc> Get(int MonHocId);
        public Task<MonHoc> getmaMonHoc(string maMonHoc);
    }
}
