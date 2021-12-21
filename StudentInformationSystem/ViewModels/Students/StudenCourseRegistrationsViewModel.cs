using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.ViewModels.Students
{
    public class StudenCourseRegistrationsViewModel
    {
        public List<Course> SelectedCourses { get; set; }
        public Student Student { get; set; }
    }
}
