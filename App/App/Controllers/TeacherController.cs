using App.Models.ViewModels;
using App.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        // 선생님 소개
        public IActionResult TeacherIntroduce()
        {
            var viewModel = teacherRepository.GetAllTeachers();

            return View(viewModel);
        }

        
        // 선생님 관리
        public IActionResult TeacherManagement()
        {
            
            return View();
        }
    }
}
