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
    }
}
