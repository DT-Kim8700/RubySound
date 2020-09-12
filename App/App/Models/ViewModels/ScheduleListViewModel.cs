using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class ScheduleListViewModel
    {
        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public Schedule Schedule { get; set; }
    }
}
