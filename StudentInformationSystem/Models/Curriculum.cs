using System.Collections.Generic;

namespace StudentInformationSystem.Models
{
    public class Curriculum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CurriculumCourse> CurriculumCourses { get; set; }
    }
}
