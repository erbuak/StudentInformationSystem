using System;

namespace StudentInformationSystem.Models
{
    public class CourseRegistration
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
