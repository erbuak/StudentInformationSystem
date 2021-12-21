using System;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Models
{
    public class Identity
    {
        public int Id { get; set; }

        public long? TcNo { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PlaceOfBirth { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
