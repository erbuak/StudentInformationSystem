using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.ViewModels.Students
{
    public class CurriculumToStudentViewModel
    {
        public int StudentNumber { get; set; }

        public int? CurrentCurriculumId { get; set; }

        public string CurrentCurriculumName { get; set; }

        public List<Curriculum> AllCurriculms { get; set; }
    }
}
