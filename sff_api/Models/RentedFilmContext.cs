using Microsoft.EntityFrameworkCore;

namespace sff_api.Models
{
    public class RentedFilmContext : DbContext
    {
        public RentedFilmContext(DbContextOptions<RentedFilmContext> options) : base(options)
        { }
        public DbSet<RentedFilm> RentedFilms { get; set; }
    }
}