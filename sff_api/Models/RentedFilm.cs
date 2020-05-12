using System;
namespace sff_api.Models
{
    public class RentedFilm
    {
        public long Id { get; set; }
        public int FilmId { get; set; }
        public int StudioId { get; set; }
        public bool Returned { get; set; }
    }
}



