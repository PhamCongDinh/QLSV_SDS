using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Repositories;

namespace QuanLySVDSD.Services
{
    public class LopService
    {
        private readonly ILopRepository _lopRepository;
        public LopService(ILopRepository lopRepository)
        {
            _lopRepository = lopRepository;
        }
        public async Task<List<Lop>> getall()
        {
            var lst = await _lopRepository.GetAll();
            return lst;
        }
        public async Task<Lop> AddLop(Lop Lop)
        {
            Lop check = await _lopRepository.getmaLop(Lop.MaLop);
            if (check == null)
            {
                return await _lopRepository.Add(Lop);
            }
            else
            {
                throw new InvalidOperationException("mã hóa đã tồn tại");
            }
        }

        public async Task<Lop> Update(Lop Lop)
        {
            //Lop notchange = await _LopRepository.Get(Lop.Id);
            ////bool hasChanges = !notchange.Equals(Lop);
            //if (notchange.Equals(Lop))
            //{
            //    throw new InvalidOperationException("bạn chưa thay đổi gì");

            //}
            //else
            //{
            Lop check = await _lopRepository.getmaLop(Lop.MaLop);
            if (check == null)
            {

                return await _lopRepository.Update(Lop);
            }
            else
            {
                throw new InvalidOperationException("mã lớp đã tồn tại");
            }
            //}
        }
    }
}
