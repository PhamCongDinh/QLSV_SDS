using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Services;

namespace QuanLySVDSD.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        private readonly SinhVienService sinhvienSer;
        public SinhViensController(SinhVienService sinhvienSer)
        {
            this.sinhvienSer = sinhvienSer;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SinhVien sinhVien)
        {
            return Ok(await sinhvienSer.AddSV(sinhVien));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await sinhvienSer.getall());
        }
    }
}
