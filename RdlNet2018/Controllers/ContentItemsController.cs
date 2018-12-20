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
    public class ContentItemsController : ControllerBase
    {
        private readonly ContentDBContext _context;

        public ContentItemsController(ContentDBContext context)
        {
            _context = context;
        }

        // GET: api/ContentItems
        [HttpGet]
        public IEnumerable<ContentItem> GetContentItems()
        {
            return _context.ContentItems;
        }

        // GET: api/ContentItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contentItem = await _context.ContentItems.FindAsync(id);

            if (contentItem == null)
            {
                return NotFound();
            }

            return Ok(contentItem);
        }

        // PUT: api/ContentItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentItem([FromRoute] int id, [FromBody] ContentItem contentItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentItem.ContentItemId)
            {
                return BadRequest();
            }

            _context.Entry(contentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentItemExists(id))
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

        // POST: api/v1/ContentItems
        [HttpPost]
        public async Task<IActionResult> PostContentItem([FromBody] ContentItem contentItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContentItems.Add(contentItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentItem", new { id = contentItem.ContentItemId }, contentItem);
        }

        // DELETE: api/ContentItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contentItem = await _context.ContentItems.FindAsync(id);
            if (contentItem == null)
            {
                return NotFound();
            }

            _context.ContentItems.Remove(contentItem);
            await _context.SaveChangesAsync();

            return Ok(contentItem);
        }

        private bool ContentItemExists(int id)
        {
            return _context.ContentItems.Any(e => e.ContentItemId == id);
        }
    }
}