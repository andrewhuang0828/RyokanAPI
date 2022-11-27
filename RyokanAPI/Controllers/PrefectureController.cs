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
    public class PrefectureController : ControllerBase
    {
        private readonly RyokanDBContext _context;

        public PrefectureController(RyokanDBContext context)
        {
            _context = context;
        }

        // GET: api/Prefecture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prefecture>>> GetPrefecture()
        {
          if (_context.Prefecture == null)
          {
              return NotFound();
          }
          
          return await _context.Prefecture.ToListAsync();
        }

        // GET: api/Prefecture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prefecture>> GetPrefecture(int id)
        {
          if (_context.Prefecture == null)
          {
              return NotFound();
          }
            var prefecture = await _context.Prefecture.FindAsync(id);

            if (prefecture == null)
            {
                return NotFound("That prefecture doesn't exist!");
            }

            return prefecture;
        }

        // PUT: api/Prefecture/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrefecture(int id, Prefecture prefecture)
        {
            if (id != prefecture.PrefectureId)
            {
                return BadRequest();
            }

            _context.Entry(prefecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefectureExists(id))
                {
                    return NotFound("That prefecture doesn't exist!");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Prefecture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prefecture>> PostPrefecture(Prefecture prefecture)
        {
          if (_context.Prefecture == null)
          {
              return Problem("Entity set 'RyokanDBContext.Prefecture'  is null.");
          }
            _context.Prefecture.Add(prefecture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrefecture", new { id = prefecture.PrefectureId }, prefecture);
        }

        // DELETE: api/Prefecture/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrefecture(int id)
        {
            if (_context.Prefecture == null)
            {
                return NotFound();
            }
            var prefecture = await _context.Prefecture.FindAsync(id);
            if (prefecture == null)
            {
                return NotFound("That prefecture doesn't exist!");
            }

            _context.Prefecture.Remove(prefecture);
            await _context.SaveChangesAsync();

            return StatusCode(202, "Successful deletion!");
        }

        private bool PrefectureExists(int id)
        {
            return (_context.Prefecture?.Any(e => e.PrefectureId == id)).GetValueOrDefault();
        }
    }
}
