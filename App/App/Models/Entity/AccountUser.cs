using App.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Account
{
    public partial class AccountUser : IdentityUser
    {
        [Key]
        public string AccountUserId { get; set; }

        // Email은 IdentityUser의 Email 필드를 사용

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }
    }

    public partial class AccountUser    // fk key partial
    {
        [ForeignKey("Id")]
        public virtual ICollection<Community> Communitys { get; set; }
    }
}
