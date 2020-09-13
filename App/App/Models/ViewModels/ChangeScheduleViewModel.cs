using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public partial class ChangeScheduleViewModel
    {
        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public Schedule Schedule { get; set; }

        public List<Schedule> Schedules { get; set; }

        public int StudentId { get; set; }

        public int ScheduleId { get; set; }
    }

    public partial class ChangeScheduleViewModel
    {
        public int ScheduleYear { get; set; }

        public int ScheduleMonth { get; set; }

        public int ScheduleDay { get; set; }

        public int ScheduleHour { get; set; }

    }

}
