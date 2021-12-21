using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.ViewModels.Courses
{
    public class CourseViewModel
    {
        [Required(ErrorMessage = "Ders kodu zorunludur.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Ders adı zorunludur.")]
        public string Name { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "Ders kredisi zorunludur.")]
        public int Credit { get; set; }
    }
}
