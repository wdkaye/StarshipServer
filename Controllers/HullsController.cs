using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarshipServer.Data;
using StarshipServer.Data.Models;

namespace StarshipServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HullsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HullsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hulls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hull>>> GetHulls()
        {
            return await _context.Hulls.ToListAsync();
        }

        // GET: api/Hulls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hull>> GetHull(int id)
        {
            var hull = await _context.Hulls.FindAsync(id);

            if (hull == null)
            {
                return NotFound();
            }

            return hull;
        }

        // PUT: api/Hulls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHull(int id, Hull hull)
        {
            if (id != hull.Id)
            {
                return BadRequest();
            }

            _context.Entry(hull).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HullExists(id))
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

        // POST: api/Hulls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hull>> PostHull(Hull hull)
        {
            _context.Hulls.Add(hull);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHull", new { id = hull.Id }, hull);
        }

        // DELETE: api/Hulls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHull(int id)
        {
            var hull = await _context.Hulls.FindAsync(id);
            if (hull == null)
            {
                return NotFound();
            }

            _context.Hulls.Remove(hull);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HullExists(int id)
        {
            return _context.Hulls.Any(e => e.Id == id);
        }
    }
}
