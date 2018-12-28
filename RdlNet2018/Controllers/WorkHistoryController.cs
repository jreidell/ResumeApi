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
    public class WorkHistoryController : ControllerBase
    {
        //private IWorkHistoryRepository _repo;
        private IRepositoryWrapper _repo;

        public WorkHistoryController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/v1/WorkHistory
        [HttpGet]
        public async Task<IEnumerable<WorkHistory>> GetWorkHistory()
        {
            return await _repo.WorkHistory.GetAllWorkHistoryItemsAsync();
        }

        // GET: api/v1/WorkHistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var workHistoryItems = await _repo.WorkHistory.GetWorkHistoryByIdAsync(id);

            if (workHistoryItems == null)
            {
                return NotFound();
            }

            return Ok(workHistoryItems);
        }

        // PUT: api/v1/WorkHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkHistory([FromRoute] Guid id, [FromBody] WorkHistory workHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workHistory.WorkHistoryId)
            {
                return BadRequest();
            }

            try
            {
                await _repo.WorkHistory.UpdateWorkHistoryAsync(workHistory);
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
        public async Task<IActionResult> PostWorkHistory([FromBody] WorkHistory workHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.WorkHistory.CreateWorkHistoryAsync(workHistory);

            return CreatedAtAction("GetWorkHistory", new { id = workHistory.WorkHistoryId }, workHistory);
        }

        private bool WorkHistoryExists(Guid id)
        {
            return (_repo.WorkHistory.GetWorkHistoryByIdAsync(id) != null);
        }
    }
}