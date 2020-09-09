using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ScheduleController : Controller
    {
        // 스케쥴 조회
        public IActionResult ScheduleLookup()
        {
            return View();
        }
    }
}
