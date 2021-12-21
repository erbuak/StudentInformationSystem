using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int StudentNumber { get; set; }

        public int IdentityId { get; set; }

        public Identity Identity { get; set; }

        public int? CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }

        public ICollection<CourseRegistration> CourseRegistrations { get; set; }
    }
}