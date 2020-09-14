using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class StudentAddViewModel
    {

        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Student.Instrument Ins { get; set; }
        public int TeacherId { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
