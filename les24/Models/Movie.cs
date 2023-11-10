using System.ComponentModel.DataAnnotations;

namespace CinemaTheater.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Director { get; set; }

        [Required]
        [MaxLength(50)]
        public string Style { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public ICollection<MovieShow> MovieShows { get; set; }
    }
}