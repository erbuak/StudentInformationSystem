using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Areas.StudentPanel.ViewModels
{
    public class CourseRegistrationViewModel
    {
        public List<Course> SelectedCourse { get; set; }
        public List<Course> UnselectedCourse { get; set; }
    }
}
