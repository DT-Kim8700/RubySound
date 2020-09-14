using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public partial class Student    // enum partial
    {
        public enum Instrument
        {
            Piano,
            Violin,
            Viola,
            Flute,
            Clarinet,
            Guitar
        }
    }
    public partial class Student    // column partial
    {
        

        [Key]
        public int StudentId { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Birthday { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Gender { get; set; }

        [Index(IsUnique = true), Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(200), Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public Instrument Ins { get; set; }

        [Required, Column(TypeName = "int")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        
    }

    public partial class Student    // fk key partial
    {
        [ForeignKey("StudentId")]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}


// Index(IsUnique = true): 유니크 설정. 인덱스도 같이 부여된다.