using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Services;

namespace QLSVDapperSDS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private readonly LopService _lopService;
        public LopController(LopService lopService)
        {
            _lopService = lopService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(LopReq lopreq)
        {
            try
            {
                return Ok(await _lopService.AddLopAsync(lopreq));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,LopReq lopReq)
        {
            try
            {
                return Ok(await _lopService.UpdateLopAsync(id,lopReq));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
