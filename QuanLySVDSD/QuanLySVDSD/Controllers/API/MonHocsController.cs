using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Services;

namespace QuanLySVDSD.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        private readonly MonHocService monHocService;
        public MonHocsController(MonHocService monHocService)
        {
            this.monHocService = monHocService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(MonHoc monHoc)
        {
            try
            {
                return Ok(await monHocService.AddMonHoc(monHoc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> get()
        {
            return Ok(await monHocService.getall());
        }
    }
}
