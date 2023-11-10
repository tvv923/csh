using System.ComponentModel.DataAnnotations;

namespace CinemaTheater.Models
{
    public class MovieShow
    {
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int ShowId { get; set; }

        public Show Show { get; set; }
    }
}
