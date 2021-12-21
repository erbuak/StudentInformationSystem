using System.Collections.Generic;

namespace StudentInformationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public int Credit { get; set; }

        public ICollection<CurriculumCourse> CurriculumCourses { get; set; }

        public ICollection<CourseRegistration> CourseRegistrations { get; set; }
    }
}
