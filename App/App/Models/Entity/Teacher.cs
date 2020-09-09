using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public partial class Teacher    // enum partial
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
    public partial class Teacher    // column partial
    {
        

        [Key]
        public int TeacherId { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Birthday { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Gender { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(200), Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public Instrument Ins { get; set; }

    } 

    public partial class Teacher    // fk key partial
    {
        [ForeignKey("TeacherId")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
