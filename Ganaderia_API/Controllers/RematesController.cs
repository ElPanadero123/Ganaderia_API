using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ganaderia_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ganaderia_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RematesController : ControllerBase
    {
        private readonly AppGanaderiaContext _context;

        public RematesController(AppGanaderiaContext context)
        {
            _context = context;
        }

        // GET: api/Remates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remate>>> GetRemates()
        {
            return await _context.Remates.Include(p=>p.Usuario).ToListAsync();
        }

        // GET: api/Remates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Remate>> GetRemate(int id)
        {
            var remate = await _context.Remates.FindAsync(id);

            if (remate == null)
            {
                return NotFound();
            }

            return remate;
        }

        // PUT: api/Remates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemate(int id, Remate remate)
        {
            if (id != remate.Id)
            {
                return BadRequest();
            }

            _context.Entry(remate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemateExists(id))
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

        // POST: api/Remates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Remate>> PostRemate(Remate remate)
        {
            _context.Remates.Add(remate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRemate", new { id = remate.Id }, remate);
        }

        // DELETE: api/Remates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemate(int id)
        {
            var remate = await _context.Remates.FindAsync(id);
            if (remate == null)
            {
                return NotFound();
            }

            _context.Remates.Remove(remate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RemateExists(int id)
        {
            return _context.Remates.Any(e => e.Id == id);
        }
    }
}
