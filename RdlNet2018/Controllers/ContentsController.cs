using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RdlNet2018.Data;
using RdlNet2018.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNet2018.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly ContentDBContext _context;

        public ContentsController(ContentDBContext context)
        {
            _context = context;
        }

        // GET: api/Contents
        [HttpGet]
        public IEnumerable<Content> GetContent()
        {
            return _context.Content;
        }

        // GET: api/v1/Contents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var content = await _context.Content.FindAsync(id);

            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        // PUT: api/v1/Contents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContent([FromRoute] int id, [FromBody] Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != content.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
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

        // POST: api/v1/Contents
        [HttpPost]
        public async Task<IActionResult> PostContent([FromBody] Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Content.Add(content);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContent", new { id = content.ContentId }, content);
        }

        // DELETE: api/v1/Contents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var content = await _context.Content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            _context.Content.Remove(content);
            await _context.SaveChangesAsync();

            return Ok(content);
        }

        private bool ContentExists(int id)
        {
            return _context.Content.Any(e => e.ContentId == id);
        }
    }
}