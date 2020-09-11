using App.Models;
using App.Models.ViewModels;
using System.Collections.Generic;

namespace App.Repository
{
    public interface ITeacherRepository
    {
        List<Student> ChargeStudents(int? teacherId);
        void Delete(int? TeacherId);
        TeacherListViewModel GetAllTeachers();
        void Save();
    }
}