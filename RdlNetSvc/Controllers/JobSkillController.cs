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
    public class JobSkillController : ControllerBase
    {
        //private IJobSkillRepository _repo;
        private IRepositoryWrapper _repo;

        public JobSkillController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/v1/JobSkill
        [HttpGet]
        public async Task<IEnumerable<JobSkill>> GetJobSkill()
        {
            return await _repo.JobSkill.GetAllJobSkillItemsAsync();
        }

        // GET: api/v1/JobSkill/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobSkill([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobSkillItems = await _repo.JobSkill.GetJobSkillByIdAsync(id);

            if (jobSkillItems == null)
            {
                return NotFound();
            }

            return Ok(jobSkillItems);
        }

        // PUT: api/v1/JobSkill/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSkill([FromRoute] Guid id, [FromBody] JobSkill jobSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobSkill.JobSkillId)
            {
                return BadRequest();
            }

            try
            {
                await _repo.JobSkill.UpdateJobSkillAsync(jobSkill);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSkillExists(id))
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

        // POST: api/v1/JobSkill
        [HttpPost]
        public async Task<IActionResult> PostJobSkill([FromBody] JobSkill jobSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.JobSkill.CreateJobSkillAsync(jobSkill);

            return CreatedAtAction("GetJobSkill", new { id = jobSkill.JobSkillId }, jobSkill);
        }

        private bool JobSkillExists(Guid id)
        {
            return (_repo.JobSkill.GetJobSkillByIdAsync(id) != null);
        }
    }
}