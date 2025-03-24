using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }

        [Column("Course Name", TypeName = "varchar(255)")]
        public string CourseName { get; set; }

        [Column("Course Description", TypeName = "text")]
        public  string CourseDescription { get; set; }

        [Column("Duration", TypeName = "varchar(50)")]
        public  string Duration { get; set; }

        [Column("Fees", TypeName = "decimal(10,2)")]
        public decimal Fees { get; set; }

        public string CourseImg { get; set; }

        [Column("Created_at", TypeName = "datetime")]
        public DateTime Created_at { get; set; }
    }
}
