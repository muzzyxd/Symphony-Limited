using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Models;

namespace Symphony_Limited.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Examination> Examinations {  get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Faq> Faqs { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Subject> Subjects { get; set; }
    }
}