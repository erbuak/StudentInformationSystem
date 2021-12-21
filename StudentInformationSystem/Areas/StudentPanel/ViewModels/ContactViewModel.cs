using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Areas.StudentPanel.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Email { get; set; }

        public long? GSM { get; set; }
    }
}
