using System;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.ViewModels.Students
{
    public class StudentViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı zorunludur."), MaxLength(15, ErrorMessage ="Kullanıcı adı maksimum 15 karakter içermelidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Şifre zorunludur."), MinLength(6, ErrorMessage ="Şifre en az 8 karakter içermelidir.")]
        public string Password { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string Surname { get; set; }


        public long? TcNo { get; set; }

        public string PlaceOfBirth { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public string Address { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Email { get; set; }

        public long? GSM { get; set; }
    }
}
