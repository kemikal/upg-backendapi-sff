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
    public class FilmstudioController : ControllerBase
    {
        private readonly FilmstudioContext _context;

        public FilmstudioController(FilmstudioContext context)
        {
            _context = context;
        }

        // GET: api/Filmstudio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filmstudio>>> GetFilmstudios()
        {
            return await _context.Filmstudios.ToListAsync();
        }

        // GET: api/Filmstudio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filmstudio>> GetFilmstudio(long id)
        {
            var filmstudio = await _context.Filmstudios.FindAsync(id);

            if (filmstudio == null)
            {
                return NotFound();
            }

            return filmstudio;
        }

        // PUT: api/Filmstudio/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmstudio(long id, Filmstudio filmstudio)
        {
            if (id != filmstudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmstudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmstudioExists(id))
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

        // POST: api/Filmstudio
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Filmstudio>> PostFilmstudio(Filmstudio filmstudio)
        {
            _context.Filmstudios.Add(filmstudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmstudio", new { id = filmstudio.Id }, filmstudio);
        }

        // DELETE: api/Filmstudio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Filmstudio>> DeleteFilmstudio(long id)
        {
            var filmstudio = await _context.Filmstudios.FindAsync(id);
            if (filmstudio == null)
            {
                return NotFound();
            }

            _context.Filmstudios.Remove(filmstudio);
            await _context.SaveChangesAsync();

            return filmstudio;
        }

        private bool FilmstudioExists(long id)
        {
            return _context.Filmstudios.Any(e => e.Id == id);
        }
    }
}
