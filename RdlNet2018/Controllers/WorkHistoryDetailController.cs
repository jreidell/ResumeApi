using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WorkHistoryDetailController : ControllerBase
    {
        private IWorkHistoryRepository _repo;

        public WorkHistoryDetailController(IWorkHistoryRepository repo)
        {
            _repo = repo;
        }

        // GET: api/v1/WorkHistory
        [HttpGet]
        public async Task<IEnumerable<WorkHistory>> GetWorkHistory()
        {
            return await _repo.GetAllWorkHistoryItemsAsync();
        }

        // GET: api/v1/WorkHistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var workHistoryDetailItems = await _repo.GetWorkHistoryByIdAsync(id);

            if (workHistoryDetailItems == null)
            {
                return NotFound();
            }

            return Ok(workHistoryDetailItems);
        }

        // PUT: api/v1/WorkHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkHistory([FromRoute] Guid id, [FromBody] WorkHistory workHistoryDetail)
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
                await _repo.UpdateWorkHistoryAsync(workHistoryDetail);
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

        // POST: api/v1/WorkHistory
        [HttpPost]
        public async Task<IActionResult> PostWorkHistory([FromBody] WorkHistory workHistoryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreateWorkHistoryAsync(workHistoryDetail);

            return CreatedAtAction("GetWorkHistory", new { id = workHistoryDetail.WorkHistoryId }, workHistoryDetail);
        }

        private bool WorkHistoryExists(Guid id)
        {
            return (_repo.GetWorkHistoryByIdAsync(id) != null);
        }
    }
}