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
    public class StudentController : Controller
    {

        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // 학생 관리
        public IActionResult StudentManagement()
        {
            var viewModel = studentRepository.GetAllStudents();

            return View(viewModel);
        }

        // 학생 삭제
        public IActionResult DeleteStudent(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("StudentManagement");
            }

            studentRepository.Delete(id);
            studentRepository.Save();

            return RedirectToAction("StudentManagement");
        }

        // 학생 추가
        public IActionResult AddStudent()
        {
            StudentViewModel viewModel = new StudentViewModel()
            {
                Teachers = studentRepository.GetTeachers()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool success = studentRepository.Add(model);

                if (success)
                {
                    studentRepository.Save();
                    return RedirectToAction("StudentManagement");
                }

                ModelState.AddModelError("", "등록 실패");

            }

            return View(model);

        }


        // 학생 정보 변경
        public IActionResult UpdateStudent(int id)      // StudentId
        {
            StudentViewModel viewModel = studentRepository.GetOneStudent(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStudent(StudentViewModel model)
        {
            bool result = studentRepository.Update(model);

            if (result)
            {
                studentRepository.Save();
                return RedirectToAction("StudentManagement");
            }

            return RedirectToAction("UpdateStudent");
        }
    } 
}
