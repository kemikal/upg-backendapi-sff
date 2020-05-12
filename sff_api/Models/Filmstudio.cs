using System;
namespace sff_api.Models
{
    public class Filmstudio
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Verified { get; set; }
    }
}
