using App.Data;
using App.Models;
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
        public IEnumerable<Teacher> GetAllTeachers()    // IEnumerable : List보다 데이터를 읽어올때 더 효율적이다.
        {
            return context.Teachers.ToList();
        }

        // 선생님 프로필 조회

        // 선생님 정보 등록

        // 선생님 스케쥴 확인
    }
}
