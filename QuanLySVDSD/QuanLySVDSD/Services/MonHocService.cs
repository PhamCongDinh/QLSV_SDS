using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Repositories;

namespace QuanLySVDSD.Services
{
    public class MonHocService
    {
        private readonly IMonHocRepository _MonHocRepository;
        public MonHocService(IMonHocRepository MonHocRepository)
        {
            _MonHocRepository = MonHocRepository;
        }
        public async Task<List<MonHoc>> getall()
        {
            var lst = await _MonHocRepository.GetAll();
            return lst;
        }
        public async Task<MonHoc> AddMonHoc(MonHoc MonHoc)
        {
            MonHoc check = await _MonHocRepository.getmaMonHoc(MonHoc.MaMonHoc);
            if (check == null)
            {
                return await _MonHocRepository.Add(MonHoc);
            }
            else
            {
                throw new InvalidOperationException("mã hóa đã tồn tại");
            }
        }

        public async Task<MonHoc> Update(MonHoc MonHoc)
        {
            //MonHoc notchange = await _MonHocRepository.Get(MonHoc.Id);
            ////bool hasChanges = !notchange.Equals(MonHoc);
            //if (notchange.Equals(MonHoc))
            //{
            //    throw new InvalidOperationException("bạn chưa thay đổi gì");

            //}
            //else
            //{
            MonHoc check = await _MonHocRepository.getmaMonHoc(MonHoc.MaMonHoc);
            if (check == null)
            {

                return await _MonHocRepository.Update(MonHoc);
            }
            else
            {
                throw new InvalidOperationException("mã lớp đã tồn tại");
            }
            //}
        }
    }
}
