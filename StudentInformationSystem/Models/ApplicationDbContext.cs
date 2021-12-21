using Microsoft.EntityFrameworkCore;

namespace StudentInformationSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Identity> Identities { get; set; }
        
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Curriculum> Curriculums { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CurriculumCourse> CurriculumCourses { get; set; }

        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
    }
}
