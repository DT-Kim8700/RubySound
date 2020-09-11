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
        public TeacherListViewModel GetAllTeachers()    // IEnumerable : List보다 데이터를 읽어올때 더 효율적이다.
        {
            var teachers = context.Teachers.ToList();

            var teacherViewModel = new TeacherListViewModel()
            {
                Teachers = teachers
            };

            return teacherViewModel;
        }

        // 선생님 프로필 조회

        // 선생님 정보 등록

        // 선생님 스케쥴 확인
    }
}
