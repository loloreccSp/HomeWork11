using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiContact.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(15)]
        public string SecondPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(250)]
        public string Information { get; set; }
    }
}
