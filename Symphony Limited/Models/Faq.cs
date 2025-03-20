using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Symphony_Limited.Models
{
    public class Faq
    {
        [Key]
        public int Faq_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Question { get; set; }

        [Required]
        [StringLength(255)]
        public string Answer { get; set; }

        [Required]
        public DateTime Created_At { get; set; }
    }
}
