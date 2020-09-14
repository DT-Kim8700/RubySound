using App.Data;
using App.Models;
using App.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public List<StudentListViewModel> GetAllStudents()
        {
            var query = from student in context.Students
                        join teacher in context.Teachers
                            on student.TeacherId equals teacher.TeacherId
                        select new { student, teacher };

            List<StudentListViewModel> studentViewModel = new List<StudentListViewModel>();

            if (query.Any())
            {
                foreach (var i in query)
                {
                    studentViewModel.Add(new StudentListViewModel
                    {
                        Student = i.student,
                        Teacher = i.teacher
                    });

                }
            }

            return studentViewModel;
        }

        // 수강생 삭제
        public void Delete(int? studentId)
        {
            var student = context.Students
                .FirstOrDefault(s => s.StudentId == studentId);

            context.Students.Remove(student);
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers.ToList();
        }

        // 수강생 등록
        public bool AddStudent(StudentAddViewModel model)
        {
            Student student = new Student
            {
                Name = model.Name,
                Birthday = model.Birthday,
                Gender = model.Gender,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Ins = model.Ins,
                TeacherId = model.TeacherId
            };

            Student findStudent = context.Students.Where(s => s.Email == student.Email).FirstOrDefault();

            if(findStudent == null)
            {
                context.Students.Add(student);
                return true;
            }

            return false;
        }


        // 수강생 검색 조회

        // 수강생 스케쥴 확인





        public void Save()
        {
            context.SaveChanges();
        }
    }
}
