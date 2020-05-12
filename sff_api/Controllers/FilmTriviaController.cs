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
    public class FilmTriviaController : ControllerBase
    {
        private readonly FilmTriviaContext _context;

        public FilmTriviaController(FilmTriviaContext context)
        {
            _context = context;
        }

        // GET: api/FilmTrivia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmTrivia>>> GetFilmTrivias()
        {
            return await _context.FilmTrivias.ToListAsync();
        }

        // GET: api/FilmTrivia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmTrivia>> GetFilmTrivia(long id)
        {
            var filmTrivia = await _context.FilmTrivias.FindAsync(id);

            if (filmTrivia == null)
            {
                return NotFound();
            }

            return filmTrivia;
        }

        // PUT: api/FilmTrivia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmTrivia(long id, FilmTrivia filmTrivia)
        {
            if (id != filmTrivia.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmTrivia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmTriviaExists(id))
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

        // POST: api/FilmTrivia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FilmTrivia>> PostFilmTrivia(FilmTrivia filmTrivia)
        {
            _context.FilmTrivias.Add(filmTrivia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmTrivia", new { id = filmTrivia.Id }, filmTrivia);
        }

        // DELETE: api/FilmTrivia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmTrivia>> DeleteFilmTrivia(long id)
        {
            var filmTrivia = await _context.FilmTrivias.FindAsync(id);
            if (filmTrivia == null)
            {
                return NotFound();
            }

            _context.FilmTrivias.Remove(filmTrivia);
            await _context.SaveChangesAsync();

            return filmTrivia;
        }

        private bool FilmTriviaExists(long id)
        {
            return _context.FilmTrivias.Any(e => e.Id == id);
        }
    }
}
