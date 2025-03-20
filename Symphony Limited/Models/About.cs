using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class About
    {
        [Key]
        public int About_Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime Created_At { get; set; }
    }
}
