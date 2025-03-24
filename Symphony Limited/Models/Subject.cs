using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Symphony_Limited.Models
{
    public class Subject
    {
        [Key]
        public int Subject_Id { get; set; }

        [Column("Subject Name", TypeName = "varchar(255)")]
        public string SubjectName { get; set; }

        [Column("Subject Description", TypeName = "text")]
        public string SubjectDescription { get; set; }

        [Column("Duration", TypeName = "varchar(50)")]
        public string Duration { get; set; }

        [Precision(10,2)]
        public decimal Fees { get; set; }

        [MaxLength(100)]
        public string SubjectImgName { get; set; }

        [Column("Created_at", TypeName = "datetime")]
        public DateTime Created_at { get; set; }
    }
}
