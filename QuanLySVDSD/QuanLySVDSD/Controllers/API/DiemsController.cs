using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySVDSD.Models.DTOCreate;
using QuanLySVDSD.Models.DTOUpdate;
using QuanLySVDSD.Services;

namespace QuanLySVDSD.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemsController : ControllerBase
    {
        private readonly DiemService _diemService;
        public DiemsController(DiemService diemService)
        {
            _diemService = diemService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(DiemDTOCr diemDTOCr)
        {
            try
            {
                return Ok(await _diemService.AddDiem(diemDTOCr));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(DiemDTOUp diemDTOUp)
        {
            return Ok(await _diemService.Update(diemDTOUp));
        }
        [HttpGet]
        public async Task<IActionResult> getbyid(int id)
        {
            return Ok(await _diemService.getdiembyid(id));
        }
    }
}
