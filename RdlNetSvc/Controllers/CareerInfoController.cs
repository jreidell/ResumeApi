using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RdlNetSvc.Common.Contracts;
using RdlNetSvc.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNetSvc.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CareerInfoController : ControllerBase
    {
        //private ICareerInfoRepository _repo;
        private IRepositoryWrapper _repo;

        public CareerInfoController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/v1/CareerInfo
        [HttpGet]
        public async Task<IEnumerable<CareerInfo>> GetCareerInfo()
        {
            return await _repo.CareerInfo.GetAllCareerInfoItemsAsync();
        }

        // GET: api/v1/CareerInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCareerInfo([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var careerInfoItems = await _repo.CareerInfo.GetCareerInfoByIdAsync(id);

            if (careerInfoItems == null)
            {
                return NotFound();
            }

            return Ok(careerInfoItems);
        }

        // PUT: api/v1/CareerInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerInfo([FromRoute] Guid id, [FromBody] CareerInfo careerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != careerInfo.CareerInfoId)
            {
                return BadRequest();
            }

            try
            {
                await _repo.CareerInfo.UpdateCareerInfoAsync(careerInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/CareerInfo
        [HttpPost]
        public async Task<IActionResult> PostCareerInfo([FromBody] CareerInfo careerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CareerInfo.CreateCareerInfoAsync(careerInfo);

            return CreatedAtAction("GetCareerInfo", new { id = careerInfo.CareerInfoId }, careerInfo);
        }

        private bool CareerInfoExists(Guid id)
        {
            return (_repo.CareerInfo.GetCareerInfoByIdAsync(id) != null);
        }
    }
}