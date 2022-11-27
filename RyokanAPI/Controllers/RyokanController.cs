using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RyokanAPI.Models;

namespace RyokanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RyokanController : ControllerBase
    {
        private readonly RyokanDBContext _context;

        public RyokanController(RyokanDBContext context)
        {
            _context = context;
        }

        // GET: api/Ryokan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ryokan>>> GetRyokan()
        {
          if (_context.Ryokan == null)
          {
              return NotFound();
          }
            return await _context.Ryokan.ToListAsync();
        }

        // GET: api/Ryokan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ryokan>> GetRyokan(int id)
        {
          if (_context.Ryokan == null)
          {
              return NotFound();
          }
            var ryokan = await _context.Ryokan.FindAsync(id);

            if (ryokan == null)
            {
                return NotFound("This ryokan doesn't exist!");
            }

            return ryokan;
        }

        // PUT: api/Ryokan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRyokan(int id, Ryokan ryokan)
        {
            if (id != ryokan.RyokanId)
            {
                return BadRequest();
            }

            _context.Entry(ryokan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RyokanExists(id))
                {
                    return NotFound("This ryokan doesn't exist!");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ryokan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ryokan>> PostRyokan(Ryokan ryokan)
        {
          if (_context.Ryokan == null)
          {
              return Problem("Entity set 'RyokanDBContext.Ryokan'  is null.");
          }
            _context.Ryokan.Add(ryokan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRyokan", new { id = ryokan.RyokanId }, ryokan);
        }

        // DELETE: api/Ryokan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRyokan(int id)
        {
            if (_context.Ryokan == null)
            {
                return NotFound();
            }
            var ryokan = await _context.Ryokan.FindAsync(id);
            if (ryokan == null)
            {
                return NotFound("That ryokan doesn't exist!");
            }

            _context.Ryokan.Remove(ryokan);
            await _context.SaveChangesAsync();

            return StatusCode(202, "Successful deletion!");
        }

        private bool RyokanExists(int id)
        {
            return (_context.Ryokan?.Any(e => e.RyokanId == id)).GetValueOrDefault();
        }
    }
}
