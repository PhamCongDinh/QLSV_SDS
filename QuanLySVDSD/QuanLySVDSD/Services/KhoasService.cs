using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Repositories;

namespace QuanLySVDSD.Services
{
    public class KhoasService
    {
        private readonly IKhoasRepository _khoasRepository;
        public KhoasService(IKhoasRepository khoasRepository)
        {
            _khoasRepository = khoasRepository;
        }
        public async Task<List<Khoas>> getall()
        {
            var lst = await _khoasRepository.GetAll();
            return lst;
        }
        public async Task<Khoas> AddKhoas(Khoas khoas)
        {
            Khoas check = await _khoasRepository.getmakhoas(khoas.MaKhoas);
            if (check == null)
            {
                return await _khoasRepository.Add(khoas);
            }else
            {
                throw new InvalidOperationException("mã hóa đã tồn tại");
            }
        }

        public async Task<Khoas> Update(Khoas khoas)
        {
            //Khoas notchange = await _khoasRepository.Get(khoas.Id);
            ////bool hasChanges = !notchange.Equals(khoas);
            //if (notchange.Equals(khoas))
            //{
            //    throw new InvalidOperationException("bạn chưa thay đổi gì");

            //}
            //else
            //{
                Khoas check = await _khoasRepository.getmakhoas(khoas.MaKhoas);
                if (check == null)
                {

                    return await _khoasRepository.Update(khoas);
                }
                else
                {
                    throw new InvalidOperationException("mã khóa đã tồn tại");
                }
            //}
        }
    }
}
