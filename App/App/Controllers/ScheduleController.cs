using App.Models.ViewModels;
using App.Repository;
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
        private readonly IScheduleRepository scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }


        // 스케쥴 조회
        public IActionResult ScheduleList()   
        {
            IEnumerable<ScheduleListViewModel> ScheduleListViewModel = scheduleRepository.GetAllSchedules();

            return View(ScheduleListViewModel);
        }


        // 스케쥴 변경 페이지
        public IActionResult ChangeSchedule(int id)       // Student.StudentId
        {
            return View();
        }



        // 스케쥴 개인 조회
        public IActionResult StudentSchedule(int id)       // Student.StudentId
        {
            return View();
        }





        // 스케쥴 취소
        public IActionResult DeleteSchedule()
        {
            return View();
        }


    }
}
