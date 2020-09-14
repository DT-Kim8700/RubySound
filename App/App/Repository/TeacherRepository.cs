using App.Data;
using App.Models;
using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationContext context;

        public TeacherRepository(ApplicationContext context)
        {
            this.context = context;
        }

        // 선생님 전체 조회
        public TeacherListViewModel GetAllTeachers()
        {
            var teachers = context.Teachers.ToList();

            var teacherViewModel = new TeacherListViewModel()
            {
                Teachers = teachers
            };

            return teacherViewModel;
        }

        // 선생님 삭제
        public void Delete(int? TeacherId)
        {
            var teacher = context.Teachers
                .FirstOrDefault(t => t.TeacherId == TeacherId);

            context.Teachers.Remove(teacher);
        }

        // 담당 학생들 조회
        public List<Student> ChargeStudents(int? teacherId)
        {
            var students = context.Students
                .Where(s => s.TeacherId == teacherId).ToList();

            return students;
        }

        // 선생님 추가
        public bool Add(TeacherViewModel model)
        {
            Teacher teacher = new Teacher
            {
                Name = model.Name,
                Birthday = model.Birthday,
                Gender = model.Gender,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Ins = model.Ins,
            };
            
            context.Teachers.Add(teacher);

            if(teacher != null)
            {
                return true;
            }

            return false;
        }

        // 선생님 프로필 수정
        public TeacherViewModel GetOneTeacher(int teacherId)
        {
            Teacher teacher = context.Teachers.Where(t => t.TeacherId == teacherId).FirstOrDefault();

            TeacherViewModel teacherView = new TeacherViewModel
            {
                TeacherId = teacher.TeacherId,
                Name = teacher.Name,
                Birthday = teacher.Birthday,
                Gender = teacher.Gender,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Address = teacher.Address,
                Ins = teacher.Ins
            };

            return teacherView;
        }

        public bool Update(TeacherViewModel model)
        {
            Teacher teacher = context.Teachers.Where(t => t.TeacherId == model.TeacherId).FirstOrDefault();

            if (teacher != null)
            {
                teacher.Name = model.Name;
                teacher.Birthday = model.Birthday;
                teacher.Gender = model.Gender;
                teacher.Email = model.Email;
                teacher.PhoneNumber = model.PhoneNumber;
                teacher.Address = model.Address;
                teacher.Ins = model.Ins;

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
