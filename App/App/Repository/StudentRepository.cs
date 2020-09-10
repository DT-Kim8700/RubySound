using App.Data;
using App.Models;
using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ApplicationContext context;

        public StudentRepository(ApplicationContext context)
        {
            this.context = context;
        }
        // 수강생 전체 조회
        public List<StudentViewModel> GetAllStudents()
        {
            List<Student> students = context.Students.ToList();
            List<Teacher> teachers = context.Teachers.ToList();

            var query = (from student in students
                         join teacher in teachers on student.TeacherId equals teacher.TeacherId
                         select new { Student = student , TeacherName = teacher.Name });

            List<StudentViewModel> studentViewModel = new List<StudentViewModel>();

            foreach (var i in query)
            {
                studentViewModel.Add(new StudentViewModel
                {
                    Student = i.Student,
                    TeacherName = i.TeacherName
                });
            }

            return studentViewModel;
        }

        // 수강생 검색 조회

        // 수강생 등록

        // 수강생 스케쥴 확인
    }
}
