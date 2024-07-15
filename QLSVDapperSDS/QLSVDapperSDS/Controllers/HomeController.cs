using Microsoft.AspNetCore.Mvc;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTORespose;
using QLSVDapperSDS.Services;
using QLSVDapperSDS.ViewModels;
using System.Diagnostics;

namespace QLSVDapperSDS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SinhVienService sinhVienService;
        private readonly DiemService diemService;
        public HomeController(ILogger<HomeController> logger, SinhVienService sinhVienService, DiemService diemService)
        {
            _logger = logger;
            this.sinhVienService = sinhVienService;
            this.diemService = diemService;
        }

        public async Task<IActionResult> Index()
        {
            IList<SinhVienRes> lstsv = await sinhVienService.GetAll();
            return View(lstsv);
        }
        public async Task<IActionResult> DetailsSV(int id)
        {
            SinhVienRes sv = await sinhVienService.Getbyid(id);
            var mh = await diemService.getdiembysv(id);
            SinhVienMonHoc svmh = new SinhVienMonHoc
            {
                SinhVienRes = sv,
                DiemRes = mh
            };
            return View(svmh);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
