using System.ComponentModel.DataAnnotations;

namespace NoteExample.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Note Title")]
        public string? Title { get; set; }

        [Required]
        public string? Text { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Tags { get; set; }
    }
}