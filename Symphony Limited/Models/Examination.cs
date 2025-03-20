using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class Examination
    {
        [Key]
        public int ExamId { get; set; }

        [Column("Exam Name", TypeName = "varchar(255)")]
        public string ExamName { get; set; }

        [Column("Exam Date", TypeName = "datetime")]
        public DateTime ExamDate { get; set; }

        [Column("Fees", TypeName = "decimal(10,2)")]
        public decimal Fees { get; set; }

        [Column("Created at", TypeName = "datetime")]
        public DateTime Created_at { get; set; }
    }
}
