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
    public class AnimalesController : ControllerBase
    {
        private readonly AppGanaderiaContext _context;

        public AnimalesController(AppGanaderiaContext context)
        {
            _context = context;
        }

        // GET: api/Animales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animale>>> GetAnimales()
        {
            return await _context.Animales.Include(p=>p.Usuario).ToListAsync();
        }

        // GET: api/Animales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animale>> GetAnimale(int id)
        {
            var animale = await _context.Animales.FindAsync(id);

            if (animale == null)
            {
                return NotFound();
            }

            return animale;
        }

        // PUT: api/Animales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimale(int id, Animale animale)
        {
            if (id != animale.Id)
            {
                return BadRequest();
            }

            _context.Entry(animale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimaleExists(id))
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

        // POST: api/Animales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animale>> PostAnimale(Animale animale)
        {
            _context.Animales.Add(animale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimale", new { id = animale.Id }, animale);
        }

        // DELETE: api/Animales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimale(int id)
        {
            var animale = await _context.Animales.FindAsync(id);
            if (animale == null)
            {
                return NotFound();
            }

            _context.Animales.Remove(animale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimaleExists(int id)
        {
            return _context.Animales.Any(e => e.Id == id);
        }
    }
}
