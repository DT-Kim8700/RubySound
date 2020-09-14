using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface ITeacherRepository
    {
        bool Add(TeacherViewModel model);
        List<Student> ChargeStudents(int? teacherId);
        void Delete(int? TeacherId);
        TeacherListViewModel GetAllTeachers();
        TeacherViewModel GetOneTeacher(int teacherId);
        void Save();
        bool Update(TeacherViewModel model);
    }
}