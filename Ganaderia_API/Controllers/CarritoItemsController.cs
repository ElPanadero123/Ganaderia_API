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
    public class CarritoItemsController : ControllerBase
    {
        private readonly AppGanaderiaContext _context;

        public CarritoItemsController(AppGanaderiaContext context)
        {
            _context = context;
        }

        // GET: api/CarritoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoItem>>> GetCarritoItems()
        {
            return await _context.CarritoItems.Include(p=>p.Producto).ToListAsync();
        }

        // GET: api/CarritoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoItem>> GetCarritoItem(int id)
        {
            var carritoItem = await _context.CarritoItems.FindAsync(id);

            if (carritoItem == null)
            {
                return NotFound();
            }

            return carritoItem;
        }

        // PUT: api/CarritoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoItem(int id, CarritoItem carritoItem)
        {
            if (id != carritoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(carritoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoItemExists(id))
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

        // POST: api/CarritoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarritoItem>> PostCarritoItem(CarritoItem carritoItem)
        {
            _context.CarritoItems.Add(carritoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarritoItem", new { id = carritoItem.Id }, carritoItem);
        }

        // DELETE: api/CarritoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoItem(int id)
        {
            var carritoItem = await _context.CarritoItems.FindAsync(id);
            if (carritoItem == null)
            {
                return NotFound();
            }

            _context.CarritoItems.Remove(carritoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoItemExists(int id)
        {
            return _context.CarritoItems.Any(e => e.Id == id);
        }
    }
}
