using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sff_api.Models;

namespace sff_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedFilmController : ControllerBase
    {
        private readonly RentedFilmContext _context;

        public RentedFilmController(RentedFilmContext context)
        {
            _context = context;
        }

        // GET: api/RentedFilm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentedFilm>>> GetRentedFilms()
        {
            return await _context.RentedFilms.ToListAsync();
        }

        // GET: api/RentedFilm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentedFilm>> GetRentedFilm(long id)
        {
            var rentedFilm = await _context.RentedFilms.FindAsync(id);

            if (rentedFilm == null)
            {
                return NotFound();
            }

            return rentedFilm;
        }

        // PUT: api/RentedFilm/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentedFilm(long id, RentedFilm rentedFilm)
        {
            if (id != rentedFilm.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentedFilm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedFilmExists(id))
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

        // POST: api/RentedFilm
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RentedFilm>> PostRentedFilm(RentedFilm rentedFilm)
        {
            _context.RentedFilms.Add(rentedFilm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentedFilm", new { id = rentedFilm.Id }, rentedFilm);
        }

        // DELETE: api/RentedFilm/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentedFilm>> DeleteRentedFilm(long id)
        {
            var rentedFilm = await _context.RentedFilms.FindAsync(id);
            if (rentedFilm == null)
            {
                return NotFound();
            }

            _context.RentedFilms.Remove(rentedFilm);
            await _context.SaveChangesAsync();

            return rentedFilm;
        }

        private bool RentedFilmExists(long id)
        {
            return _context.RentedFilms.Any(e => e.Id == id);
        }
    }
}
