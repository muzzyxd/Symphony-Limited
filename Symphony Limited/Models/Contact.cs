using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string BranchName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Created_at { get; set; }
    }
}
