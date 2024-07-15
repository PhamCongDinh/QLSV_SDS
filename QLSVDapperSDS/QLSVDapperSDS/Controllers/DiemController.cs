using Microsoft.AspNetCore.Mvc;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Models.DTORespose;
using QLSVDapperSDS.Services;

namespace QLSVDapperSDS.Controllers
{
    public class DiemController : Controller
    {
        private readonly DiemService _diemService;
        public DiemController(DiemService diemService)
        {
            _diemService = diemService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            DiemRes diem = await _diemService.getdiembyid(id);
            return View(diem);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var diem = await _diemService.getdiembyid(id);
            DiemReq diemreq = new DiemReq
            {
                DiemQuaTrinh = diem.DiemQuaTrinh,
                DiemThanhPhan = diem.DiemThanhPhan,
            };
            return View(diemreq);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, DiemReq diemReq)
        {
            if (ModelState.IsValid)
            {
                var updatediem=await _diemService.UpdateDiem(id,diemReq);
                return RedirectToAction("Details", new { id = id });
            }
            return View(diemReq);

        }
    }
}
