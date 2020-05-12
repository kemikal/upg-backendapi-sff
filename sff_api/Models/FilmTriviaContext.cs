using Microsoft.EntityFrameworkCore;

namespace sff_api.Models
{
    public class FilmTriviaContext : DbContext
    {
        public FilmTriviaContext(DbContextOptions<FilmTriviaContext> options) : base(options)
        { }
        public DbSet<FilmTrivia> FilmTrivias { get; set; }
    }
}
