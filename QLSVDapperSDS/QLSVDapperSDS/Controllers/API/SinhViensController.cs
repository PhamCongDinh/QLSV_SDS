using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Services;

namespace QLSVDapperSDS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        private readonly SinhVienService sinhVienService;
        public SinhViensController(SinhVienService sinhVienService)
        {
            this.sinhVienService = sinhVienService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await sinhVienService.GetAll());
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult>  getbyid(int id)
        {
            return Ok(await sinhVienService.Getbyid(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(SinhVienReq sinhVienReq)
        {
            try
            {
                return Ok(await sinhVienService.AddSinhVienAsync(sinhVienReq));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
