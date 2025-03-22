using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Feedback
    {
        [Key]

        public int Feedback_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string YourName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        public string UserFeedback { get; set; }
    }
}
