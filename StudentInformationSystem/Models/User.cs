using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public bool Type { get; set; }

        public int? IdentityId { get; set; }

        public Identity Identity { get; set; }
    }
}
