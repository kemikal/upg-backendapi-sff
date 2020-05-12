using Microsoft.EntityFrameworkCore;

namespace sff_api.Models
{
    public class FilmstudioContext : DbContext
    {
        public FilmstudioContext(DbContextOptions<FilmstudioContext> options) : base(options)
        { }
        public DbSet<Filmstudio> Filmstudios { get; set; }
    }
}
