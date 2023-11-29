using System.ComponentModel.DataAnnotations;

namespace HomeWork11.Models
{
    public class NoteModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string NameNote { get; set; }
        [Required]
        public string TextNote { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Tags { get; set; }
    }
}
