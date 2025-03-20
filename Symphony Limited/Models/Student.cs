using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RollNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string StudentName { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Marks { get; set; }

        [Required]
        [StringLength(50)]
        public string Class_Assigned { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Fees_Paid { get; set; }

        [Required]
        public DateTime Created_At { get; set; }
    }
}
