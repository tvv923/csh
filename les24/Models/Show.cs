using System.ComponentModel.DataAnnotations;

namespace CinemaTheater.Models
{
    public class Show
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        [RegularExpression(@"^(11|13|15|17|19|21)$", ErrorMessage = "Недопустимое значение ShowTime. Допустимые значения: 11, 13, 15, 17, 19, 21.")]
        public string ShowTime { get; set; }

        public ICollection<MovieShow> MovieShows { get; set; }
    }
}
