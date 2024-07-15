using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSVDapperSDS.Services;

namespace QLSVDapperSDS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemsController : ControllerBase
    {
        private readonly DiemService diemService;
        public DiemsController(DiemService diemService)
        {
            this.diemService = diemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetdiembySV(int svid)
        {
            return Ok(await diemService.getdiembysv(svid));
        }
    }
}
