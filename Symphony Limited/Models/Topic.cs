using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Required]
        public string TopicName { get; set; }

        // Foreign key
        public int CourseId { get; set; }

        // Navigation property
        public Course Course { get; set; }
    }
}
