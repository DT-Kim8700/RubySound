using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class StudentListViewModel
    {
        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
