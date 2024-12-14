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
    public class ReactorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReactorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reactors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reactor>>> GetReactors()
        {
            return await _context.Reactors.ToListAsync();
        }

        // GET: api/Reactors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reactor>> GetReactor(int id)
        {
            var reactor = await _context.Reactors.FindAsync(id);

            if (reactor == null)
            {
                return NotFound();
            }

            return reactor;
        }

        // PUT: api/Reactors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReactor(int id, Reactor reactor)
        {
            if (id != reactor.Id)
            {
                return BadRequest();
            }

            _context.Entry(reactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactorExists(id))
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

        // POST: api/Reactors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reactor>> PostReactor(Reactor reactor)
        {
            _context.Reactors.Add(reactor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReactor", new { id = reactor.Id }, reactor);
        }

        // DELETE: api/Reactors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReactor(int id)
        {
            var reactor = await _context.Reactors.FindAsync(id);
            if (reactor == null)
            {
                return NotFound();
            }

            _context.Reactors.Remove(reactor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReactorExists(int id)
        {
            return _context.Reactors.Any(e => e.Id == id);
        }
    }
}
