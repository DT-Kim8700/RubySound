using App.Models.Account;
using App.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class CommunityCreateViewModel
    {
        public Community Community { get; set; }

        public AccountUser AccountUser { get; set; }
    }
}
