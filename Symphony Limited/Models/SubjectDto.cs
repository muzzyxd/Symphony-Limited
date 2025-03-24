using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Symphony_Limited.Models
{
    public class SubjectDto
    {
        [Required,MaxLength(100)]
        public string SubjectName { get; set; }

        [Required]
        public string SubjectDescription { get; set; }

        [Required, MaxLength(100)]
        public string Duration { get; set; }

        [Required]
        public decimal Fees { get; set; }

        
        public IFormFile? ImageFile { get; set; }

    }
}
