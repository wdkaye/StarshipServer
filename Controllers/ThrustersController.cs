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
    public class ThrustersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThrustersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Thrusters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thruster>>> GetThrusters()
        {
            return await _context.Thrusters.ToListAsync();
        }

        // GET: api/Thrusters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thruster>> GetThruster(int id)
        {
            var thruster = await _context.Thrusters.FindAsync(id);

            if (thruster == null)
            {
                return NotFound();
            }

            return thruster;
        }

        // PUT: api/Thrusters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThruster(int id, Thruster thruster)
        {
            if (id != thruster.Id)
            {
                return BadRequest();
            }

            _context.Entry(thruster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThrusterExists(id))
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

        // POST: api/Thrusters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thruster>> PostThruster(Thruster thruster)
        {
            _context.Thrusters.Add(thruster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThruster", new { id = thruster.Id }, thruster);
        }

        // DELETE: api/Thrusters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThruster(int id)
        {
            var thruster = await _context.Thrusters.FindAsync(id);
            if (thruster == null)
            {
                return NotFound();
            }

            _context.Thrusters.Remove(thruster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThrusterExists(int id)
        {
            return _context.Thrusters.Any(e => e.Id == id);
        }
    }
}
