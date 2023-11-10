using System.ComponentModel.DataAnnotations;

namespace NoteExample.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contact Name")]
        public string? Name { get; set; }

        [Required]
        public string? Phone { get; set; }
                
        public string? AlternativePhone { get; set; }

        [Required]
        public string? Email { get; set; }
                
        public string? Description { get; set; }
    }
}