using App.Data;
using App.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationContext context;

        public HomeRepository(ApplicationContext context)
        {
            this.context = context;
        }


    }
}
