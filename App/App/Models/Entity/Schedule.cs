using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Schedule
    {
        public enum Status
        {
            Waiting,
            Completion
        }


        [Key]
        public int ScheduleId { get; set; }

        [Required]
        public DateTime ScheduleTime { get; set; }

        [Required, Column(TypeName = "int")]
        public int StudentId { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public Status LessonStatus { get; set; }

        public virtual Student Student { get; set; }
    }
}
