using Microsoft.AspNetCore.Mvc;
using RdlMvcUI.Models;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RdlMvcUI.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryWrapper _repo;

        public HomeController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New([FromBody] CareerInfo careerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CareerInfo.CreateCareerInfoAsync(careerInfo);

            return CreatedAtAction("GetCareerInfo", new { id = careerInfo.CareerInfoId }, careerInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("{*url}", Order = 999)]
        public IActionResult CatchAll()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
