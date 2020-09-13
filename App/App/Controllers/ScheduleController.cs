using App.Models;
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
        public IActionResult ChangeSchedule(int? id)       // Student.StudentId
        {
            ChangeScheduleViewModel viewModel = scheduleRepository.GetOneSchedules(id);

            return View(viewModel);
            
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // 스케쥴 추가
        public IActionResult ChangeSchedule(ChangeScheduleViewModel model)
        {
            if (model.ScheduleId != 0)          // 스케쥴 삭제
            {
                scheduleRepository.Delete(model.ScheduleId);
                scheduleRepository.Save();
            }
            else    // 스케쥴 추가
            {
                Student student = model.Student;

                scheduleRepository.AddSchedule(model);
            }

            scheduleRepository.Save();

            return RedirectToAction("ChangeSchedule");
        }


        // 스케쥴 개인 조회
        public IActionResult StudentSchedule(int id)       // Student.StudentId
        {
            return View();
        }



        // 스케쥴 취소
        //public IActionResult DeleteSchedule(int? id)     // ScheduleId
        //{

        //    if (id == null)
        //    {
        //        return RedirectToAction("changeSchedule");
        //    }

        //    scheduleRepository.Delete(id);
        //    scheduleRepository.Save();

        //    return RedirectToAction("changeSchedule");
        //}


    }
}
