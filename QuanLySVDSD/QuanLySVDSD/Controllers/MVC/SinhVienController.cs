using Microsoft.AspNetCore.Mvc;
using QuanLySVDSD.Models.DTORead;
using QuanLySVDSD.Services;
using QuanLySVDSD.ViewModels;

namespace QuanLySVDSD.Controllers.MVC
{
    public class SinhVienController : Controller
    {
        private readonly SinhVienService sinhvienSer;
        private readonly DiemService diemService;
        public SinhVienController(SinhVienService sinhvienSer, DiemService diemService)
        {
            this.sinhvienSer = sinhvienSer;
            this.diemService = diemService;
        }
        public async Task<IActionResult> Index()
        {
            IList<SinhVienDTOR> lstsv = await sinhvienSer.getall();

            return View(lstsv);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            SinhVienDTOR sinhVien = await sinhvienSer.getbyid(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            var monhoc = await diemService.getdiembySVid(id);
            SinhVienMonHoc sinhVienMonHoc = new SinhVienMonHoc
            {
                SinhVienDTOR = sinhVien,
                DiemDTOR = monhoc
            };
            return View(sinhVienMonHoc);
        }

    }
}
