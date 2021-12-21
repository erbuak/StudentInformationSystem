using System;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.ViewModels.Students
{
    public class StudentUpdateViewModel
    {
        public int IdentityId { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string Surname { get; set; }

        public long? TcNo { get; set; }

        public string PlaceOfBirth { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ContactId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Email { get; set; }

        public long? GSM { get; set; }
    }
}
