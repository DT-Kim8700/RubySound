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



        // 선생님 프로필 조회

        // 선생님 정보 등록

        // 선생님 스케쥴 확인





        public void Save()
        {
            context.SaveChanges();
        }
    }
}
