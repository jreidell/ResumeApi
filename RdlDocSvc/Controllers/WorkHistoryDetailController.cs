using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlDocSvc.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkHistoryDetailController : ControllerBase
    {
        //private IWorkHistoryRepository _repo;
        private IRepositoryWrapper _repo;

        public WorkHistoryDetailController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/v1/WorkHistoryDetail
        [HttpGet]
        public async Task<IEnumerable<WorkHistoryDetail>> GetWorkHistoryDetail()
        {
            return await _repo.WorkHistoryDetail.GetAllWorkHistoryDetailItemsAsync();
        }

        // GET: api/v1/WorkHistoryDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkHistoryDetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var workHistoryDetailItems = await _repo.WorkHistoryDetail.GetWorkHistoryDetailByIdAsync(id);

            if (workHistoryDetailItems == null)
            {
                return NotFound();
            }

            return Ok(workHistoryDetailItems);
        }

        // PUT: api/v1/WorkHistoryDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkHistory([FromRoute] Guid id, [FromBody] WorkHistoryDetail workHistoryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workHistoryDetail.WorkHistoryId)
            {
                return BadRequest();
            }

            try
            {
                await _repo.WorkHistoryDetail.UpdateWorkHistoryDetailAsync(workHistoryDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkHistoryExists(id))
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

        // POST: api/v1/WorkHistoryDetail
        [HttpPost]
        public async Task<IActionResult> PostWorkHistory([FromBody] WorkHistoryDetail workHistoryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.WorkHistoryDetail.CreateWorkHistoryDetailAsync(workHistoryDetail);

            return CreatedAtAction("GetWorkHistory", new { id = workHistoryDetail.WorkHistoryId }, workHistoryDetail);
        }

        private bool WorkHistoryExists(Guid id)
        {
            return (_repo.WorkHistoryDetail.GetWorkHistoryDetailByIdAsync(id) != null);
        }
    }
}