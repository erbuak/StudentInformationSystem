using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.ViewModels.Curriculums
{
    public class CurriculumViewModel
    {
        [Required(ErrorMessage ="Müfredat adı zorunludur.")]
        public string Name { get; set; }
    }
}
