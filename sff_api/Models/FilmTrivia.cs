using System;
namespace sff_api.Models
{
    public class FilmTrivia
    {
        public long Id { get; set; }
        public int FilmId { get; set; }
        public string Trivia { get; set; }
    }
}
