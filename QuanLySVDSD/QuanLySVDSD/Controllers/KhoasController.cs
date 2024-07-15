using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using QuanLySVDSD.Models.DTO;
using QuanLySVDSD.Services;
using ISession = NHibernate.ISession;

namespace QuanLySVDSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoasController : ControllerBase
    {
        // readonly ISessionFactory _sessionFactory;
        //private readonly ISession _db;
        
        //public KhoasController(ISessionFactory sessionFactory)
        //{
        //    _db = sessionFactory.OpenSession();
        //}
        //[HttpGet]
        //public IActionResult get()
        //{
        //    List<Khoas> khoas = _db.Query<Khoas>().ToList();
        //    return Ok(khoas);
        //}
        //[HttpPost]
        //public IActionResult Post(Khoas khoas)
        //{
        //    ITransaction transaction = _db.BeginTransaction();
        //    _db.Save(khoas);
        //    transaction.Commit();
        //    return Ok(khoas);

        //}

        private readonly KhoasService khoasService;
        public KhoasController(KhoasService khoasService)
        {
            this.khoasService = khoasService;
        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            var lst = await khoasService.getall();
            if (lst == null)
            {
                return BadRequest();
            }
            return Ok(lst);
        }
        [HttpPost]
        public async Task<IActionResult> post(Khoas khoas)
        {
            try
            {
                return Ok(await khoasService.AddKhoas(khoas));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> put(Khoas khoas)
        {
            try
            {
                return Ok(await khoasService.Update(khoas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
