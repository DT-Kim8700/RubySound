using App.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public class Community
    {
        [Key]
        public int CommunityId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime EnrollTime { get; set; }

        public virtual AccountUser AccountUser { get; set; }
    }
}
