using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Core.ControllersApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariansController : ControllerBase
    {
        private readonly Core.Entities.AppContext _context;

        public LibrariansController(Core.Entities.AppContext context)
        {
            _context = context;
        }

        // GET: api/Librarians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Librarians>>> GetLibrarians()
        {
            return await _context.Librarians.ToListAsync();
        }

        // GET: api/Librarians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Librarians>> GetLibrarians(int id)
        {
            var librarians = await _context.Librarians.FindAsync(id);

            if (librarians == null)
            {
                return NotFound();
            }

            return librarians;
        }

        // PUT: api/Librarians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrarians(int id, Librarians librarians)
        {
            if (id != librarians.LId)
            {
                return BadRequest();
            }

            _context.Entry(librarians).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrariansExists(id))
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

        // POST: api/Librarians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Librarians>> PostLibrarians(Librarians librarians)
        {
            _context.Librarians.Add(librarians);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrarians", new { id = librarians.LId }, librarians);
        }

        // DELETE: api/Librarians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrarians(int id)
        {
            var librarians = await _context.Librarians.FindAsync(id);
            if (librarians == null)
            {
                return NotFound();
            }

            _context.Librarians.Remove(librarians);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibrariansExists(int id)
        {
            return _context.Librarians.Any(e => e.LId == id);
        }
    }
}
