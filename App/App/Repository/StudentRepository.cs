using App.Data;
using App.Models;
using App.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        public bool Add(StudentViewModel model)
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

        // 수강생 개인 정보
        public StudentViewModel GetOneStudent(int studentId)
        {
            var query = from student in context.Students
                        join teacher in context.Teachers
                        on student.StudentId equals studentId
                        select new { student, teacher };

            Student getStudent = query.FirstOrDefault().student;
            Teacher getTeacher = query.FirstOrDefault().teacher;
            IEnumerable<Teacher> teachers = context.Teachers.ToImmutableList();

            StudentViewModel studentViewModel = new StudentViewModel
            {
                StudentId = getStudent.StudentId,
                Name = getStudent.Name,
                Birthday = getStudent.Birthday,
                Gender = getStudent.Gender,
                Email = getStudent.Email,
                PhoneNumber = getStudent.PhoneNumber,
                Address = getStudent.Address,
                Ins = getStudent.Ins,
                TeacherId = getStudent.TeacherId,
                Teacher = getTeacher,
                Teachers = teachers
            };

            return studentViewModel;
        }

        // 수강생 개인정보 수정
        public bool Update(StudentViewModel model)
        {
            Student student = context.Students.Where(s => s.StudentId == model.StudentId).FirstOrDefault();

            if (student != null)
            {
                student.Name = model.Name;
                student.Birthday = model.Birthday;
                student.Gender = model.Gender;
                student.Email = model.Email;
                student.PhoneNumber = model.PhoneNumber;
                student.Address = model.Address;
                student.Ins = model.Ins;
                student.TeacherId = model.TeacherId;

                return true;
            }

            return false;
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
