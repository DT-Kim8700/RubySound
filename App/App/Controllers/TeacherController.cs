using App.Models;
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

        
        // 선생님 리스트 조회 및 관리
        public IActionResult TeacherManagement()
        {
            var viewModel = teacherRepository.GetAllTeachers();

            return View(viewModel);

        }
        

        // 선생님 삭제
        public IActionResult DeleteTeacher(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("TeacherManagement");
            }

            // 담당 학생이 한 명도 없을 시 삭제가능
            List<Student> students = teacherRepository.ChargeStudents(id);

            if (students.Count == 0)
            {
                teacherRepository.Delete(id);
                teacherRepository.Save();

                return RedirectToAction("TeacherManagement");
            }

            return RedirectToAction("index", "Home");
        }


        // 선생님 추가
        public IActionResult AddTeacher()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTeacher(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool success = teacherRepository.Add(model);

                if (success)
                {
                    teacherRepository.Save();
                    return RedirectToAction("TeacherManagement");
                }

                ModelState.AddModelError("", "등록 실패");

            }

            return View(model);
        }


        // 선생님 정보 변경
        public IActionResult UpdateTeacher(int id)      // TeacherId
        {
            TeacherViewModel viewModel = teacherRepository.GetOneTeacher(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTeacher(TeacherViewModel model)
        {
            bool result = teacherRepository.Update(model);

            if (result)
            {
                teacherRepository.Save();
                return RedirectToAction("TeacherManagement");
            }

            return RedirectToAction("UpdateTeacher");
        }

    }
}
