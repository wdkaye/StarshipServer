﻿using System;
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
    public class StarshipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StarshipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Starships
        [HttpGet]
        public async Task<ActionResult<IList<StarshipDTO>>> GetStarships()
        {
            IQueryable<StarshipDTO> q = _context.Starships.Select(static s => new StarshipDTO()
            {
                Name = s.Name,
                HullName = s.Hull!.Name,  // Throws null pointer?
                ReactorName = s.Reactor!.Name,
                ThrusterName = s.Thruster!.Name,
                WeaponName = s.Weapon!.Name,
                MassTotal = s.Hull.Mass + s.Reactor.Mass + s.Thruster.Mass + s.Weapon.Mass
            });
            
            return await q.ToListAsync();
        }

        // GET: api/Starships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Starship>> GetStarship(int id)
        {
            var starship = await _context.Starships.FindAsync(id);

            if (starship == null)
            {
                return NotFound();
            }

            return starship;
        }

        // PUT: api/Starships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarship(int id, Starship starship)
        {
            if (id != starship.Id)
            {
                return BadRequest();
            }

            _context.Entry(starship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarshipExists(id))
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

        // POST: api/Starships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Starship>> PostStarship(Starship starship)
        {
            _context.Starships.Add(starship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStarship", new { id = starship.Id }, starship);
        }

        // DELETE: api/Starships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarship(int id)
        {
            var starship = await _context.Starships.FindAsync(id);
            if (starship == null)
            {
                return NotFound();
            }

            _context.Starships.Remove(starship);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StarshipExists(int id)
        {
            return _context.Starships.Any(e => e.Id == id);
        }
    }
}
