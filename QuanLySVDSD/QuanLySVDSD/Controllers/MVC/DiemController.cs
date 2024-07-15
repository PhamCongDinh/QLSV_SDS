using Microsoft.AspNetCore.Mvc;
using QuanLySVDSD.Models.DTORead;
using QuanLySVDSD.Models.DTOUpdate;
using QuanLySVDSD.Services;

namespace QuanLySVDSD.Controllers.MVC
{
    public class DiemController : Controller
    {
        private readonly DiemService diemService;
        public DiemController(DiemService diemService)
        {
            this.diemService = diemService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            DiemDTOR diemDTOR = await diemService.getdiembyid(id);
            return View(diemDTOR);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // DiemDTOR diemDTOR = await diemService.getdiembyid(id);
            //return View(diemDTOR);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DiemDTOUp diemDTOUp)
        {
            if(ModelState.IsValid)
            {
                await diemService.Update(diemDTOUp);
                return RedirectToAction("Details", new { id = diemDTOUp.Id });
            }
            return View(diemDTOUp);

        }
    }
}
